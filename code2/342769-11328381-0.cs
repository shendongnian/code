	<#@ template debug="true" hostspecific="true" language="C#" #>
	<#@ output extension=".edmx" #>
	<#@ assembly name="System.Xml" #>
	<#@ assembly name="System.Xml.Linq" #>
	<#@ assembly name="System.Core" #>
	<#@ import namespace="System.Xml.Linq" #>
	<#@ import namespace="System.Linq" #>
	<#@ import namespace="System.Collections.Generic" #>
	<#
		var edmx = XDocument.Load(this.Host.ResolvePath("MyData.edmx"));
		var edmxns = edmx.Root.Name.Namespace;
		var csdl = edmx.Root.Element(edmxns + "Runtime").Element(edmxns + "ConceptualModels");
		var csdlSchema = csdl.Elements().First();
		var csdlns = csdlSchema.Name.Namespace;
		var modelns = csdlSchema.Attribute("Namespace").Value;
		var InheritiedObjects = new List<InheritedObject>();
		// GET LIST OF INHERITS
		foreach (var a in csdlSchema.Elements(csdlns + "Association").Where(ca => ca.Attribute("Name").Value.StartsWith("in"))) {
			InheritedObject io = new InheritedObject() { ForeignKey = a.Attribute("Name").Value };
			try {
				io.QualifiedParent = a.Elements(csdlns + "End").Single(cae => cae.Attribute("Multiplicity").Value == "1").Attribute("Type").Value;
				io.QualifiedChild = a.Elements(csdlns + "End").Single(cae => cae.Attribute("Multiplicity").Value == "0..1").Attribute("Type").Value;
				InheritiedObjects.Add(io);
			} catch {
				Warning("Foreign key '" + io.ForeignKey + "' doesn't contain parent and child roles with the correct multiplicity.");
			}	
		}
		// SET ABSTRACT OBJECTS
		foreach (var ao in InheritiedObjects.Distinct()) {
			WriteLine("<!-- ABSTRACT: {0} -->", ao.Parent);
			csdlSchema.Elements(csdlns + "EntityType")
				.Single(et => et.Attribute("Name").Value == ao.Parent)
				.SetAttributeValue("Abstract", "true");
		}
		WriteLine("<!-- -->");
	
		// SET INHERITANCE
		foreach (var io in InheritiedObjects) {
			XElement EntityType = csdlSchema.Elements(csdlns + "EntityType").Single(cet => cet.Attribute("Name").Value == io.Child);
			WriteLine("<!-- INHERITED OBJECT: {0} -->", io.Child);
	
			// REMOVE THE ASSOCIATION SET
			csdlSchema.Element(csdlns + "EntityContainer")
				.Elements(csdlns + "AssociationSet")
				.Single(cas => cas.Attribute("Association").Value == modelns + "." + io.ForeignKey)
				.Remove();
			WriteLine("<!--     ASSOCIATION SET {0} REMOVED -->", modelns + "." + io.ForeignKey);
			// REMOVE THE ASSOCIATION
			csdlSchema.Elements(csdlns + "Association")
				.Single(ca => ca.Attribute("Name").Value == io.ForeignKey)
				.Remove();
			WriteLine("<!--     ASSOCIATION {0} REMOVED -->", io.ForeignKey);
			// GET THE CHILD ENTITY SET NAME
			io.ChildSet = csdlSchema.Element(csdlns + "EntityContainer")
				.Elements(csdlns + "EntitySet")
				.Single(es => es.Attribute("EntityType").Value == io.QualifiedChild)
				.Attribute("Name").Value;
			// GET THE PARENT ENTITY SET NAME
			io.ParentSet = csdlSchema.Element(csdlns + "EntityContainer")
				.Elements(csdlns + "EntitySet")
				.Single(es => es.Attribute("EntityType").Value == io.QualifiedParent)
				.Attribute("Name").Value;
			// UPDATE ALL ASSOCIATION SETS THAT REFERENCE THE CHILD ENTITY SET
			foreach(var a in csdlSchema.Element(csdlns + "EntityContainer").Elements(csdlns + "AssociationSet")) {
				foreach (var e in a.Elements(csdlns + "End")) {
					if (e.Attribute("EntitySet").Value == io.ChildSet) e.SetAttributeValue("EntitySet", io.ParentSet);
				}
			}			
			// REMOVE THE ENTITY SET
			csdlSchema.Element(csdlns + "EntityContainer")
				.Elements(csdlns + "EntitySet")
				.Single(es => es.Attribute("EntityType").Value == io.QualifiedChild)
				.Remove();
			WriteLine("<!--     ENTITY SET {0} REMOVED -->", io.QualifiedChild);
			// SET BASE TYPE
			EntityType.SetAttributeValue("BaseType", io.QualifiedParent);
			WriteLine("<!--     BASE TYPE SET TO {0} -->", io.QualifiedParent);
			// REMOVE KEY
			EntityType.Element(csdlns + "Key").Remove();
			WriteLine("<!--     KEY REMOVED -->");
			// REMOVE ID PROPERTY
			EntityType.Elements(csdlns + "Property")
				.Where(etp => etp.Attribute("Name").Value == "ID")
				.Remove();
			WriteLine("<!--     ID PROPERTY REMOVED -->");
			// REMOVE NAVIGATION PROPERTIES THAT REFERENCE THE OLD ASSOCIATION
			List<XElement> NavList = new List<XElement>();
			foreach (var np in csdlSchema.Descendants(csdlns + "NavigationProperty")) {
				if (np.Attribute("Relationship").Value == modelns + "." + io.ForeignKey) {
					WriteLine("<!--     REMOVING NAVIGATION PROPERTY {0} FROM {1} -->", np.Attribute("Name").Value, np.Parent.Attribute("Name").Value);
					NavList.Add(np);
				
				}
			}
			NavList.ForEach(n => n.Remove());
			// REMOVE NAVIGATION PROPERTIES FROM THE PARENT THAT POINTS TO A FOREIGN KEY OF THE CHILD
			foreach (var np in EntityType.Elements(csdlns + "NavigationProperty")) {
				csdlSchema.Elements(csdlns + "EntityType")
					.Single(cet => cet.Attribute("Name").Value == io.Parent)
					.Elements(csdlns + "NavigationProperty")
					.Where(pet => pet.Attribute("Name").Value == np.Attribute("Name").Value)
					.Remove();
			}
			WriteLine("<!-- -->");
		}
		Write(edmx.ToString());
	#>
	<#+
		public class InheritedObject : IEquatable<InheritedObject> {
			public string ForeignKey { get; set; }
			public string QualifiedParent { get; set; }
			public string QualifiedChild { get; set; }			
			public string Parent { get { return RemoveNamespace(QualifiedParent); }	}
			public string Child { get { return RemoveNamespace(QualifiedChild); } }
			public string ParentSet { get; set; }
			public string ChildSet { get; set; }
			private string RemoveNamespace(string expr) {
				if (expr.LastIndexOf(".") > -1) 
					return expr.Substring(expr.LastIndexOf(".") + 1);
				else
					return expr;
			}
		
			public bool Equals(InheritedObject other) {
				if (Object.ReferenceEquals(other, null)) return false;
				if (Object.ReferenceEquals(this, other)) return true;
				return QualifiedParent.Equals(other.QualifiedParent);
			}
			public override int GetHashCode() {
				return QualifiedParent.GetHashCode();
			}
		}
	#>

	 class Program
	  {
		static void Main(string[] args)
		{
		  XmlSchemaSet schemaSet = MergeSchemas(@"..\..\XMLSchema1.xsd", @"..\..\XMLSchema2.xsd");
		  foreach (XmlSchema schema in schemaSet.Schemas())
		  {
			schema.Write(Console.Out);
			Console.WriteLine();
		  }
		}
		public static XmlSchemaSet MergeSchemas(string schema1, string schema2)
		{
		  XmlSchemaSet schemaSet1 = new XmlSchemaSet();
		  schemaSet1.Add(null, schema1);
		  schemaSet1.Compile();
		  XmlSchemaSet schemaSet2 = new XmlSchemaSet();
		  schemaSet2.Add(null, schema2);
		  schemaSet2.Compile();
		  foreach (XmlSchemaElement el1 in schemaSet1.GlobalElements.Values)
		  {
			foreach (XmlSchemaElement el2 in schemaSet2.GlobalElements.Values)
			{
			  if (el2.QualifiedName.Equals(el1.QualifiedName))
			  {
				((XmlSchema)el2.Parent).Items.Remove(el2);
				break;
			  }
			}
		  }
		  foreach (XmlSchema schema in schemaSet2.Schemas())
		  {
			schemaSet2.Reprocess(schema);
		  }
		  schemaSet2.Compile();
		  schemaSet1.Add(schemaSet2);
		  return schemaSet1;
		}
	  }

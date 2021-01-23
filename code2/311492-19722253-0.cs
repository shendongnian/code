    namespace Edmx_Manager_V1._0
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Xml;
    
        public static class RenameManager
        {
            public static XmlDocument Document = new XmlDocument();
            public static string FilePath;
            public static XmlNamespaceManager nsmgr;
    
            /// <summary>
            /// Updates the conceptual models section.
            /// </summary>
            public static void UpdateConceptualModelsSection()
            {
    
                ///////////////////////update ConceptualModels section//////////////////////////////////////////////////////////
    
                XmlNodeList Schema = Document.SelectNodes("/edmx:Edmx/edmx:Runtime/edmx:ConceptualModels/edm:Schema", nsmgr);
    
                XmlNode SchemaNode = Schema[0];
                XmlElement SchemaNodeXmlElement = SchemaNode as XmlElement;
    
                //get all EntitySet nodes under  EntityContainer node
                XmlNodeList EntitySetlist = SchemaNodeXmlElement.GetElementsByTagName("EntitySet");
    
                //get all EntityType nodes under  SchemaNode
                XmlNodeList EntityTypelist = SchemaNodeXmlElement.GetElementsByTagName("EntityType");
    
                foreach (XmlNode EntityTypenode in EntityTypelist)
                {
    
                    //to call GetElementsByTagName we need XmlElement object
                    XmlElement EntityTypenodeelement = EntityTypenode as XmlElement;
    
                    //get all PropertyRef nodes under  EntityType node
                    XmlNodeList PropertyReflist = EntityTypenodeelement.GetElementsByTagName("PropertyRef");
    
                    foreach (XmlNode PropertyRefnode in PropertyReflist)
                    {
                        //update name attribute of Key/PropertyRef nodes
                        XmlAttribute PropertyRef_nameAttribute = PropertyRefnode.Attributes["Name"];
                        PropertyRef_nameAttribute.Value = UppercaseFirst(PropertyRef_nameAttribute.Value);
                    }
    
                    //get all Property nodes under  EntityType node
                    XmlNodeList Propertylist = EntityTypenodeelement.GetElementsByTagName("Property");
    
                    foreach (XmlNode Propertynode in Propertylist)
                    {
                        //update name attribute of PropertyRef nodes
                        XmlAttribute Property_nameAttribute = Propertynode.Attributes["Name"];
                        Property_nameAttribute.Value = UppercaseFirst(Property_nameAttribute.Value);
                    }
    
                    //get all NavigationProperty nodes under  EntityType node
                    XmlNodeList NavigationPropertylist = EntityTypenodeelement.GetElementsByTagName("NavigationProperty");
    
                    foreach (XmlNode NavigationPropertynode in NavigationPropertylist)
                    {
                        //update name attribute of NavigationProperty nodes
                        XmlAttribute NavigationPropertynode_nameAttribute = NavigationPropertynode.Attributes["Name"];
                        NavigationPropertynode_nameAttribute.Value = UppercaseFirst(NavigationPropertynode_nameAttribute.Value) + "s";// we append "s" for nav properties
                    }
                }
    
                //get  Association node under  Schema node
                XmlNodeList Associationlist = SchemaNodeXmlElement.GetElementsByTagName("Association");
    
                //get all Association nodes and process
                foreach (XmlNode AssociationNode in Associationlist)
                {
                    if (AssociationNode != null)
                    {
                        XmlElement AssociationNodeXmlElement = AssociationNode as XmlElement;
                        //get all end nodes under Association
                        XmlNodeList EndNodelist2 = AssociationNodeXmlElement.GetElementsByTagName("End");
    
                        //get all PropertyRef nodes under Association
                        XmlNodeList PropertyReflist2 = AssociationNodeXmlElement.GetElementsByTagName("PropertyRef");
    
                        foreach (XmlNode PropertyRefNode2 in PropertyReflist2)
                        {
                            //update Type attribute
                            XmlAttribute PropertyRefNode2Attribute = PropertyRefNode2.Attributes["Name"];
                            PropertyRefNode2Attribute.Value = UppercaseFirst(PropertyRefNode2Attribute.Value);
                        }
                    }
                }
    
                Console.WriteLine("ConceptualModelSection updated..");
            }
    
            /// <summary>
            /// Updates the mappings section.
            /// </summary>
            public static void UpdateMappingsSection()
            {
    
                ///////////////////////update edmx:Mappings section//////////////////////////////////////////////////////////
    
                XmlNodeList EntityContainerMapping = Document.SelectNodes("/edmx:Edmx/edmx:Runtime/edmx:Mappings/cs:Mapping", nsmgr);
                XmlNode EntityContainerMapping_Node = EntityContainerMapping[0];
                XmlElement EntityContainerMappingNode_XmlElement = EntityContainerMapping_Node as XmlElement;
    
                // update name attribute of all EntitySetMapping nodes
    
                //get all EntitySetMapping nodes
                XmlNodeList EntitySetMappinglist = EntityContainerMappingNode_XmlElement.GetElementsByTagName("EntitySetMapping");
    
                //get all EntityTypeMapping nodes
                XmlNodeList EntityTypeMappinglist = EntityContainerMappingNode_XmlElement.GetElementsByTagName("EntityTypeMapping");
    
                //get all ScalarProperty nodes
                XmlNodeList ScalarPropertyist = EntityContainerMappingNode_XmlElement.GetElementsByTagName("ScalarProperty");
    
                foreach (XmlNode ScalarPropertyNode in ScalarPropertyist)
                {
                    XmlAttribute nameAttribute = ScalarPropertyNode.Attributes["Name"];
                    nameAttribute.Value = UppercaseFirst(nameAttribute.Value);
                }
    
                Console.WriteLine("MappingSection updated..");
            }
    
            /// <summary>
            /// Uppercases the first.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns></returns>
            private static string UppercaseFirst(string name)
            {
    
                return char.ToUpper(name[0]) + name.Substring(1);
    
            }
        }
    }

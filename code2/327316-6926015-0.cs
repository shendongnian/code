DataSet dtTree = ObjUser.GetAllClientGroupandList();
             TreeView1.Nodes.Clear();
             if (dtTree != null)   
            {
                // Create DataRelation.................  
                DataRelation rel = new DataRelation("ClientCategory", dtTree.Tables[0].Columns["TPAClientGroupId"],
                dtTree.Tables[1].Columns["TPAClientGroupId"], false);
                rel.Nested = true;
                dtTree.Relations.Add(rel);
                 // Set the Attribute here .........................
                foreach (DataColumn dc in dtTree.Tables[0].Columns)
                {
                    dc.ColumnMapping = MappingType.Attribute;
                }
                foreach (DataColumn dc in dtTree.Tables[1].Columns)
                {
                    dc.ColumnMapping = MappingType.Attribute;
                }
               // xml decleartion ......................................
                XmlDataSource xmlD = new System.Web.UI.WebControls.XmlDataSource();
                xmlD.ID = "XmlDataSource1";
                // Call GetXml and assign to xml data source. 
                XmlDataSource1.Data = dtTree.GetXml();
            }

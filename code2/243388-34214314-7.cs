                if (!File.Exists(@"SomeFilePath.xml")) { throw new Exception("XML File Was Not Found!"); }
                string strXML = File.ReadAllText(@"SomeFilePath.xml");
                StringReader sr = new StringReader(strXML);
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(sr);
                Func<string, string, int, string> GetFieldValue = (t, f, x) => (dsXML.Tables[t].Columns.Contains(f) && dsXML.Tables[t].Rows.Count >= x + 1) ? dsXML.Tables[t].Rows[x][f].ToString() : "";
                //-Load data from dynamically created dataset into strings.
                string str1 = GetFieldValue("Table1", "Field1", 0);
                string str2 = GetFieldValue("Table2", "Field2", 0);
                string str3 = GetFieldValue("Table3", "Field3", 0);
                //-And so on.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            } 
   

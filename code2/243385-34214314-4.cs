    //-Pull xml from file and dynamically create a dataset.
     string strXML = File.ReadAllText(@"SomeFilePath.xml");
     StringReader sr = new StringReader(strXML);
     DataSet dsXML = new DataSet();
     dsXML.ReadXml(sr);
    
    string str1 = dsXML.Tables["Table1"].Rows[0]["Field1"].ToString();
    string str2 = dsXML.Tables["Table2"].Rows[0]["Field2"].ToStrin();
    string str3 = dsXML.Tables["Table3"].Rows[0]["Field3"].ToStrin();
    string str4 = dsXML.Tables["Table4"].Rows[0]["Field4"].ToString();
    string str5 = dsXML.Tables["Table5"].Rows[0]["Field5"].ToString();

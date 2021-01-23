    public void CompareXml()
    {
        DataSet xml1DS = new DataSet("Xml1");
        DataSet xml2DS = new DataSet("Xml2");	
        DataSet outputDS = new DataSet("Output");		
    
        //read in our files
        try
        {
            xml1DS.ReadXml(@"C:\xml1.xml", XmlReadMode.Auto);
            xml2DS.ReadXml(@"C:\xml2.xml", XmlReadMode.Auto);
        }
        catch (Exception)
        {
    
        }
    
        outputXML = xml2DS;
    
        IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
    
        foreach (DataRow row1 in xml1DS.Tables["Id"].Rows)
        {
            bool hasRow = false;
            foreach (DataRow row2 in xml2DS.Tables["Id"].Rows)
            {
                try
                {
                    if ((string)row1["idN"] == (string)row2["idN"])
                    {
                        DataRow[] Child1 = row1.GetChildRows("Id_cls")[0].GetChildRows("cls_cl");
                        DataRow[] Child2 = row2.GetChildRows("Id_cls")[0].GetChildRows("cls_cl");
    
                        foreach (var v in Child1)
                        {
                            foreach (var t in Child2)
                            {
                                //string str = v.GetParentRow("columns_column").GetParentRow("configId_columns")["idNumber"].ToString();
    
    
                                if ((v["clPos"].ToString() == t["clPos"].ToString()) &&
                                    (v["cLName"].ToString() == t["cLName"].ToString())
                                    )
                                {
                                    hasRow = true;
    
                                    if (IsColumnNodeEqual(v, t) == false)
                                    {
                                        t["cName"] = "###";
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                catch(Exception)
                {
                }
    
            }
    
            if(!hasRow) 
            {
               
            }
        }
    
        //write it to the xml file
        outputXML.WriteXml("newXML.xml");
    
     }

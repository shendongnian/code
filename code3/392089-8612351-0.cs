    DataSet dst = new DataSet();
        dst.ReadXmlSchema("C:\\sdn.xsd");
        dst.ReadXml("C:\\sdn.xml");
        // Now you have list of tables that contain all information you need.
        // For example punlishinformation
        DataTable dtPubInfo  = dst.Tables["publshInformation"];
        string publishdateInfo = dtPubInfo.Rows[0]["Publish_Date"].ToString();
        string recordCount = dtPubInfo.Rows[0]["Record_Count"].ToString();
        DataTable dtsdnEtry = dst.Tables["sdnentry"];
        // GEt all SDN entry
        foreach (DataRow dr in dtsdnEtry)
            {
                
            }
           // This way you get all table and many of them contain relation that you used to insert into Oracle
            
           

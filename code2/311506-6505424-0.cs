        string myXMLfile = @"C:\MySchema.xml";
        DataSet ds = new DataSet();
        // Create new FileStream with which to read the schema.
        System.IO.FileStream fsReadXml = new System.IO.FileStream 
            (myXMLfile, System.IO.FileMode.Open);
        try
        {
            ds.ReadXml(fsReadXml);
            dataGrid1.DataSource = ds.Tables[0];
            //dataGrid1.DataMember = "Cust";
            dataGrid1.DataBind();
        }
        catch (Exception ex)
        {
    	
        }
        finally
        {
    	fsReadXml.Close();
        }

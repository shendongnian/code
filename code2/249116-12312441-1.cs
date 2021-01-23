        try
        {
           XmlDocument xdoc = new XmlDocument();    
        SqlConnection cnn = null;    
        SqlCommand cmd = null;    
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["____"].ConnectionString); // connection string from web.config
            cnn.Open();
            string strUSP = "USP_XMLStoredProcedureName"; // SP must return hierarchy of menu items. 
            cmd = new SqlCommand(strUSP, cnn);
            XmlReader reader = cmd.ExecuteXmlReader();
            if (reader.Read())
		    {
	                xdoc.Load(reader);
		    }
       // DRAG AND DROP XMLDataSource from toolbox , provide id as "DataSourceXML"
            DataSourceXML.Data = xdoc.InnerXml.ToString();
            DataSourceXML.XPath = "/ParentMenu/SubMenu";   // To avoid root
                   // :: Provide XMLDatasource ID to Menucontrol.
          // OR
         
        XmlDataSource XDS = new XmlDataSource();
        XDS.ID = "XMLDataSourceID";
        XDS.Data= xdoc.InnerXml;
        XDS.XPath = "/ParentMenu/SubMenu";   // To avoid root
        MyMenu.DataSource = XDS;
        MyMenu.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            cnn.Close();
        }

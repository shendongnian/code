    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    
    namespace ASPNetCookbook.CSExamples
    {
      public class CH01DataGridWithXMLCS : System.Web.UI.Page
      {
        
        private void Page_Load(object sender, System.EventArgs e)
        {
          const String Region_TABLE = "Region";
    
          DataSet dSet = null;
          String xmlFilename = null;
    
          if (!Page.IsPostBack)
          {
            try
            {
              // get fully qualified path to the "Region" xml document located
                               
                                xmlFilename = Server.MapPath("xml") + "\\Region.xml";
    
    
                                dSet = new DataSet( );
                                dSet.ReadXml(xmlFilename);
    
                                // bind the dataset to the datagrid
                                dgRegion.DataSource = dSet.Tables[Region_TABLE];
                               dgRegion.DataBind( );
            }  
    
            finally
            {
              // cleanup
              if (dSet != null)
              {
                dSet.Dispose( );
              }
            }  // finally
          }
        }  // Page_Load
      }  
    }

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    class Sample
    {
    static void Main(string[] args)
    {
        ReportingService2010 rs = new ReportingService2010();
        rs.Url = "http://<Server Name>" + 
            "/_vti_bin/ReportServer/ReportService2010.asmx";
        rs.Credentials = 
            System.Net.CredentialCache.DefaultCredentials;
        string name = "AdventureWorks.rsds";
        string parent = "http://<Server Name>/Docs/Documents/";
        // Define the data source definition.
        DataSourceDefinition definition = new DataSourceDefinition();
        definition.CredentialRetrieval = 
            CredentialRetrievalEnum.Integrated;
        definition.ConnectString = 
            "data source=(local);initial catalog=AdventureWorks";
        definition.Enabled = true;
        definition.EnabledSpecified = true;
        definition.Extension = "SQL";
        definition.ImpersonateUserSpecified = false;
        //Use the default prompt string.
        definition.Prompt = null;
        definition.WindowsCredentials = false;
        try
        {
            rs.CreateDataSource(name, parent, false, 
                definition, null);
        }
        catch (SoapException e)
        {
            Console.WriteLine(e.Detail.InnerXml.ToString());
        }
    }
    }

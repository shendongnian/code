    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.SharePoint;
    using Microsoft.Office.Word.Server.Conversions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "http://localhost";
            // If you manually installed Word automation services, then replace the name
            // in the following line with the name that you assigned to the service when
            // you installed it.
            string wordAutomationServiceName = "Word Automation Services";
            using (SPSite spSite = new SPSite(siteUrl))
            {
                ConversionJob job = new ConversionJob(wordAutomationServiceName);
                job.UserToken = spSite.UserToken;
                job.Settings.UpdateFields = true;
                job.Settings.OutputFormat = SaveFormat.PDF;
                job.AddFile(siteUrl + "/Shared%20Documents/Test.docx",
                    siteUrl + "/Shared%20Documents/Test.pdf");
                job.Start();
            }
        }
    }

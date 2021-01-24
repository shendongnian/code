      public string GetCustomUI(string ribbonID)
            {
                string ribbonXML = String.Empty;
        
                if (ribbonID == "Microsoft.Outlook.Report")
                {
                    ribbonXML = GetResourceText("MicrosoftOutlookReport.xml");
                }
        
                return ribbonXML;
            }
    

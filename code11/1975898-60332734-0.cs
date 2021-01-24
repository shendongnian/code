    using EnvDTE;
     public DTE dte;
    public void RunStarted(object automationObject,
     Dictionary<string, string> replacementsDictionary,           
      WizardRunKind runKind, object[] customParams)          
     {
    dte = automationObject as DTE;
     }
    public void RunFinished()
            {
                foreach (Window documentWindow in dte.Windows)
                {
            //close all Document type of windows from the output project  
                    if (documentWindow.Kind == "Document")
                    {
                        documentWindow.Close();
                    }
                }
    
            }
    

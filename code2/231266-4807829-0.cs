        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Url
        {
            get
            { 
                object urlObject = ViewState["Url"];
                if (urlObject == null)
                {
                    if (DesignMode)
                    { 
                        // Get a reference to the Visual Studio IDE
                        EnvDTE.DTE dte = this.Site.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
                        // Interface for accessing the web application in VS
                        IWebApplication webApplication = (IWebApplication)this.Site.GetService(typeof(IWebApplication));
                    
                        // Path of document being edited (Web form in web application)
                        string activeDocumentPath = dte.ActiveDocument.Path;
                        
                        // Physical path to the web application root
                        string projectPath = webApplication.RootProjectItem.PhysicalPath;
                        // Create virtal path
                        string relativePath = activeDocumentPath.Replace(projectPath, "~\\");
                        
                        return relativePath.Replace('\\','/');
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
                else
                {
                    return (string)urlObject;
                }
            }
            set
            {
                ViewState["Url"] = value;
            }
        }

            private static readonly ILog log = LogManager.GetLogger(typeof(Global));
            protected void Application_Error(object sender, EventArgs e)
            {
                if (Context != null)
                {
                    Exception error = Context.Server.GetLastError().GetBaseException();
                    log.Fatal(
                        GetErrorMessage(), error);
                }
            }
            private string GetErrorMessage()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Application_Error: Unhandled exception has been occured.");
                try
                {
                    sb.AppendLine("Current Request: " + Context.Request.RawUrl);
                    Sitecore.Data.Items.Item currentItem = Sitecore.Context.Item;
                    if (currentItem != null)
                        sb.AppendLine(String.Format("Current Item ({0}): {1}", currentItem.ID, currentItem.Paths.FullPath));
                    if (Sitecore.Context.Database != null)
                        sb.AppendLine("Current Database: " + Sitecore.Context.Database.Name);
                }
                catch { } // in no way should we prevent the site from logging the error
                return sb.ToString();
                        
            }

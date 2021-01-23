    using System;
    using System.Globalization;
    using System.Linq;
    using System.Security.Principal;
    
    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Web.Administration;
    
    namespace MyCustomActionLibrary
    {
        public static class CustomActions
        {
            /// <summary>
            /// Updates the binding for a Site.  IIS.  Right click a Site.  Select "Edit Bindings" to see GUI of this.
            /// </summary>
            /// <param name="session">The session.</param>
            /// <returns>An ActionResult</returns>
            [CustomAction]
            public static ActionResult UpdateBinding(Session session)
            {
                session.Log("Begin UpdateBinding");
    
                string siteName = session["SITE"];
                if (string.IsNullOrEmpty(siteName))
                {
                    session.Log("Property 'SITE' missing");
                    return ActionResult.NotExecuted;
                }
    
                string bindingInformation = session["BINDINGINFORMATION"];
                if (string.IsNullOrEmpty(bindingInformation))
                {
                    session.Log("Property 'BINDINGINFORMATION' missing");
                    return ActionResult.NotExecuted;
                }
    
                string bindingProtocol = session["BINDINGPROTOCOL"];
                if (string.IsNullOrEmpty(bindingProtocol))
                {
                    session.Log("Property 'BINDINGPROTOCOL' missing");
                    return ActionResult.NotExecuted;
                }
    
                ActionResult result = ActionResult.Failure;
    
                if (CheckRunAsAdministrator())
                {
                    session.Log("Start UpsertBinding.");
                    bool outcome = UpsertBinding(session, siteName, bindingInformation, bindingProtocol);
                    if (outcome)
                    {
                        result = ActionResult.Success;
                    }
    
                    session.Log("End UpsertBinding.");
                    return result;
                }
                else
                {
                    session.Log("Not running with elevated permissions.STOP");
                    session.DoAction("NotElevated");
                    return ActionResult.Failure;
                }
            }
    
            /// <summary>
            /// Enables the protocols.  Go to IIS.  Pick a Site.  Right Click an Application.  Select "Manage Application" / "Advanced Settings".  Find "Enabled Protocols" to see the GUI of this setting.
            /// </summary>
            /// <param name="session">The session.</param>
            /// <returns>An ActionResult</returns>
            [CustomAction]
            public static ActionResult EnableProtocols(Session session)
            {
                session.Log("Begin EnableProtocols");
    
                string siteName = session["SITE"];
                if (string.IsNullOrEmpty(siteName))
                {
                    session.Log("Property 'SITE' missing");
                    return ActionResult.NotExecuted;
                }
    
                string alias = session["VIRTUALDIRECTORYALIAS"];
                if (string.IsNullOrEmpty(alias))
                {
                    session.Log("Property 'VIRTUALDIRECTORYALIAS' missing");
                    return ActionResult.NotExecuted;
                }
    
                string protocols = session["ENABLEDPROTOCOLS"];
                if (string.IsNullOrEmpty(protocols))
                {
                    session.Log("Property 'ENABLEDPROTOCOLS' missing");
                    return ActionResult.NotExecuted;
                }
    
                try
                {
                    if (CheckRunAsAdministrator())
                    {
                        ServerManager manager = new ServerManager();
    
                        var site = manager.Sites.FirstOrDefault(x => x.Name.ToUpper(CultureInfo.CurrentCulture) == siteName.ToUpper(CultureInfo.CurrentCulture));
                        if (site == null)
                        {
                            session.Log("Site with name {0} not found", siteName);
                            return ActionResult.NotExecuted;
                        }
    
                        var application = site.Applications.FirstOrDefault(x => x.Path.ToUpper(CultureInfo.CurrentCulture).Contains(alias.ToUpper(CultureInfo.CurrentCulture)));
                        if (application == null)
                        {
                            session.Log("Application with path containing {0} not found", alias);
                            return ActionResult.NotExecuted;
                        }
    
                        session.Log("About to set EnabledProtocols.  SITE='{0}', VIRTUALDIRECTORYALIAS='{1}',  ENABLEDPROTOCOLS='{2}'.", siteName, alias, protocols);
                        application.EnabledProtocols = protocols;
                        manager.CommitChanges();
                        session.Log("ServerManager.CommitChanges successful for setting EnabledProtocols. SITE='{0}', VIRTUALDIRECTORYALIAS='{1}',  ENABLEDPROTOCOLS='{2}'.", siteName, alias, protocols);
    
                        return ActionResult.Success;
                    }
                    else
                    {
                        session.Log("Not running with elevated permissions.STOP");
                        session.DoAction("NotElevated");
                        return ActionResult.Failure;
                    }
                }
                catch (Exception exception)
                {
                    session.Log("Error setting enabled protocols: {0}", exception.ToString());
                    return ActionResult.Failure;
                }
            }
    
            private static bool UpsertBinding(Session session, string sitename, string bindingInformation, string bindingProtocol)
            {
                bool result;
    
                session.Log(string.Format("(SiteName)='{0}'", sitename));
                session.Log(string.Format("(BindingInformation)='{0}'", bindingInformation));
                session.Log(string.Format("(BindingProtocol)='{0}'", bindingProtocol));
    
                using (ServerManager serverManager = new ServerManager())
                {
                    Site site = serverManager.Sites.FirstOrDefault(x => x.Name.Equals(sitename, StringComparison.OrdinalIgnoreCase));
    
                    if (null != site)
                    {
                        Binding foundBinding = site.Bindings.FirstOrDefault(b => b.Protocol.Equals(bindingProtocol, StringComparison.OrdinalIgnoreCase) && b.BindingInformation.Equals(bindingInformation, StringComparison.OrdinalIgnoreCase));
    
                        if (null == foundBinding)
                        {
                            //// add bindings
                            session.Log("About add to Site.Bindings.  SITE='{0}', BINDINGINFORMATION='{1}',  BINDINGPROTOCOL='{2}'.", sitename, bindingInformation, bindingProtocol);
                            site.Bindings.Add(bindingInformation, bindingProtocol);
                            serverManager.CommitChanges();
                            session.Log("ServerManager.CommitChanges successsful for adding to Site.Bindings.  SITE='{0}', BINDINGINFORMATION='{1}',  BINDINGPROTOCOL='{2}'.", sitename, bindingInformation, bindingProtocol);
                            result = true;
                        }
                        else
                        {
                            session.Log(string.Format("Binding already exists.  (SiteName='{0}', bindingInformation='{1}', bindingProtocol='{2}')", sitename, bindingInformation, bindingProtocol));
                            result = true; /* do not fail if the binding already exists, the point is to have the binding */
                        }
                    }
                    else
                    {
                        session.Log(string.Format("Site does not exist.  (SiteName) {0}.", sitename));
                        result = false;
                    }
                }
    
                return result;
            }
    
            /// <summary>
            /// Check that process is being run as an administrator
            /// </summary>
            /// <returns>if the process is being run as administrator</returns>
            private static bool CheckRunAsAdministrator()
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }

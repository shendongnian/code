    namespace MvcWebApplication 
    { 
        // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
        // visit http://go.microsoft.com/?LinkId=9394801 
     
        public class MvcApplication : System.Web.HttpApplication 
        { 
            private string _licensefile; 
     
            internal string LicenseFile 
            { 
                get 
                { 
                    if (String.IsNullOrEmpty(_licensefile)) 
                    { 
                        string tempMylFile = Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(LDLL.License)).Location), "License.l"); 
                        if (!File.Exists(tempMylFile)) 
                            File.Copy(Server.MapPath("~/Content/license/License.l"), 
                                tempMylFile, 
                                true); 
                        _licensefile = tempMylFile; 
                    } 
                    return _licensefile; 
                } 
            }
            protected void Application_Start()
            {
                Application["LicenseFile"] = LicenseFile;
    
                AreaRegistration.RegisterAllAreas();
    
                RegisterGlobalFilters(GlobalFilters.Filters);
                RegisterRoutes(RouteTable.Routes);
            }
        }
    }

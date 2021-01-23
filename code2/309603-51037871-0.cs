        private static Exception startException;
         protected void Application_Start()
                {
                    try
                    {
                        AreaRegistration.RegisterAllAreas();
                        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                        RouteConfig.RegisterRoutes(RouteTable.Routes);
                        BundleConfig.RegisterBundles(BundleTable.Bundles);
                        ModelBinders.Binders.Add(typeof(DateTime), new MyDateTimeModelBinder());
        
                    }
                    catch (Exception ex)
                    {
                        startException = ex;
                    }
                }
      static HashSet<string> allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".js", ".css", ".png",".jpg",".jpeg",".gif",".bmp"
    };
    
            public bool IsStaticFile(HttpRequest request)
         {  //My project was a mix of asp.net web forms & mvc so had to write this      
                    if (Request.RawUrl.ToLower().Contains("/bundles/") || Request.RawUrl.ToLower().Contains("/frontendcss?") ||
                         Request.RawUrl.ToLower().Contains("/fonts/") 
    //these are my css & js bundles. a bit of hack but works for me.
                         )
                    {
                    return true;
                }
                string fileOnDisk = request.PhysicalPath;
                if (string.IsNullOrEmpty(fileOnDisk))
                {
                    return false;
                }
    
                string extension = Path.GetExtension(fileOnDisk).ToLower();
    
                return allowedExtensions.Contains(extension);
            }
         protected void Application_BeginRequest()
                {
                    if (startException != null && Request.RawUrl.ToLower() == "/Error.aspx".ToLower())
                    {
                        return;
                    }
                    if (startException != null && IsStaticFile(Request))
                    {
                        return;
                    }
        
                    if (startException != null && Request.RawUrl.ToLower()!= "/Error.aspx".ToLower())
                    {
                        //Response.Redirect("Error.aspx");
                        Server.Transfer("Error.aspx");
                        this.Context.AddError(startException);                
                        return;
                    }
        
                   
                }
            protected void Application_Error(object sender, EventArgs e)
                    {
                       Exception exception = Server.GetLastError();
                         Response.Clear();
                        Server.ClearError(); 
                       Server.Transfer("Error.aspx");     
                    }

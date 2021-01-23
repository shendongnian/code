    public class HttpRedirectModule: IHttpModule
        {
           
            public HttpRedirectModule()
            {
                
            }
    
            public void Init(HttpApplication context)
            {
                context.BeginRequest += new EventHandler(ContextBeginRequest);
                
            }
    
            void ContextBeginRequest(object sender, EventArgs e)
            {
                var application = (HttpApplication) sender;
                if (application.Application["Redirects"] == null)
                {
                    var repository = Factory.GetInstance<IRepository>();
                    application.Application["Redirects"] = repository.GetAll<Redirect>();
                }
                
                var redirects = (IList<Redirect>) application.Application["Redirects"];
                if (application.Request.Url.AbsolutePath != "/default.aspx")
                {
                    foreach (var redirect in redirects)
                    {
                        var regex = new Regex(redirect.FromPath);
                        Match match = regex.Match(application.Request.Url.AbsolutePath);
                        if (match.Success)
                        {
    
                            application.Response.Clear();
                            if (redirect.StatusCode == 301)
                            {
                                application.Response.Status = "301 Moved Permanently";
                                application.Response.StatusCode = 301;
                            }
                            else
                            {
                                application.Response.Status = "302 Moved temporarily";
                                application.Response.StatusCode = 302;
                            }
                            application.Response.AddHeader("Location", redirect.ToPath);
                            application.Response.End();
    
                        }
                    }
                }
            }
    
    
            public void Dispose()
            {
               
            }
        }
    <system.webServer>
    		<modules runAllManagedModulesForAllRequests="true">
    		<remove name="RedirectsModule" />
          <add name="RedirectsModule" type="MyCode.HttpModules.HttpRedirectModule, MyCode" />
    </modules>
    </system.webServer>

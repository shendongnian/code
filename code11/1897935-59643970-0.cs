    using System;
    using System.ServiceModel;
    using System.Web.Http;
    using System.Web.Http.SelfHost;
    
    namespace MYWebAPI
    {
        public class WebApiProgram : IDisposable
        {
            private string URL = "http://localhost:1234/";
            private HttpSelfHostServer server;
    
            public WebApiProgram()
            {
    
            }
            public WebApiProgram(string url)
            {
                this.URL = url;
    
            }
    
            public void Dispose()
            {
                server.CloseAsync().Wait();
            }
    
            public void Start()
            {
    
                var config = new HttpSelfHostConfiguration(URL);
                config.TransferMode = TransferMode.Streamed;
                
                AddAPIRoute(config);
    
                server = new HttpSelfHostServer(config);
                var task = server.OpenAsync();
                task.Wait();
                //Console.WriteLine("Web API Server has started at:" + URL);
                //Console.ReadLine();
    
            }
    
            private void AddAPIRoute(HttpSelfHostConfiguration config)
            {
                config.Routes.MapHttpRoute(
                    name: "ActionApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
            }
        }

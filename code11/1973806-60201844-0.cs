public void ConfigureServices(IServiceCollection services)
{
    Uri endPointA = new Uri("http://localhost:58919/"); // this is the endpoint HttpClient will hit
    HttpClient httpClient = new HttpClient()
    {
        BaseAddress = endPointA,
    };
 
    ServicePointManager.FindServicePoint(endPointA).ConnectionLeaseTimeout = 60000; // sixty seconds
 
    services.AddSingleton<HttpClient>(httpClient); // note the singleton
    services.AddMvc();
}

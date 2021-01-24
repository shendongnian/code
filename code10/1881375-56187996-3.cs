    public class ApiSelfHost : Startup
    {
    	public override void Configuration(IAppBuilder app)
    	{
    		app.UseCors(CorsOptions.AllowAll);
    
    		var httpConfiguration = new HttpConfiguration();
    
    		var container = httpConfiguration.ConfigureAutofac();
    
    		app.UseAutofacMiddleware(container);
    		app.UseAutofacWebApi(httpConfiguration);
    
    		app.UseWebApi(httpConfiguration);
    	}
    }

c#
//Branch the pipeline for requests that start with "/signalr"
app.Map("/signalr", map =>
{
	map.UseCors(CorsOptions.AllowAll);
	var hubConfiguration = new HubConfiguration { };
	hubConfiguration.EnableDetailedErrors = true;
	map.RunSignalR(hubConfiguration);
});

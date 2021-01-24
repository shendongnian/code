public void ConfigureServices(IServiceCollection services)
{
	// ... 
	services
		.AddMvc(options =>
		{
			options.EnableEndpointRouting = false;
			options.Filters.Add<Filters.LogApiIoContentsActionFilter>();
			options.ValueProviderFactories.Add(new BearerTokenValueProviderFactory());
			options.ValueProviderFactories.Add(new RawQueryStringValueProviderFactory());
		}).AddNewtonsoftJson();
	// ...
}
Which I already did for the `BearerTokenFromHeaderAttribute`... but forgot to do for the `RawQueryStringAttribute`
Now everything works like a charm.

    services.AddApiVersioning(options =>
			{
				var apiVersion = new ApiVersion(1, 0);
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
				options.DefaultApiVersion = apiVersion;
				options.ReportApiVersions = true;
				options.AssumeDefaultVersionWhenUnspecified = true;
			});

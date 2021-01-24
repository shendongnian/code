        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder builder, Action<IEndpointRouteBuilder> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }
            VerifyRoutingServicesAreRegistered(builder);
            VerifyEndpointRoutingMiddlewareIsRegistered(builder, out var endpointRouteBuilder);
            configure(endpointRouteBuilder);
            // Yes, this mutates an IOptions. We're registering data sources in a global collection which
            // can be used for discovery of endpoints or URL generation.
            //
            // Each middleware gets its own collection of data sources, and all of those data sources also
            // get added to a global collection.
            var routeOptions = builder.ApplicationServices.GetRequiredService<IOptions<RouteOptions>>();
            foreach (var dataSource in endpointRouteBuilder.DataSources)
            {
                routeOptions.Value.EndpointDataSources.Add(dataSource);
            }
            return builder.UseMiddleware<EndpointMiddleware>();
        }

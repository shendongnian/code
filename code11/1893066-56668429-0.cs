            public static IApplicationBuilder UseNoCachingPolicy( this IApplicationBuilder applicationBuilder )
            {
                return applicationBuilder.Use( async (context, next) => {
                        if(/*this request is one I don't want to cache*/)
                        {
                            context
							        .Response
									.OnStarting( state => {
										            var responseContext = (HttpContext)state;
                                                    //remove the header you don't want in the `responseContext`
                                                    return Task.CompletedTask;
                                         }, context );
                        }
                        await next();
                });
            }

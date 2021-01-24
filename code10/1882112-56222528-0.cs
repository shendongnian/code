    app.Use((context, next) =>
                    {
                        var request = context.Request;
                        var host = request.Host;
                        if (host.Host.Equals("customdomainurl", StringComparison.OrdinalIgnoreCase))
                        {
                            context.Response.Redirect(UriHelper.Encode(request.Scheme, newHost,
                                request.PathBase, request.Path, request.QueryString));
                            return Task.FromResult(0);
                        }
                        return next();
                    });

    Get["/providers"] = _ =>
                {
                    var providers = this.interactiveDiagnostics
                                        .AvailableDiagnostics
                                        .Select(p => new { p.Name, p.Description, Type = p.GetType().Name, p.GetType().Namespace, Assembly = p.GetType().Assembly.GetName().Name })
                                        .ToArray();
                    return Response.AsJson(providers);
                };

            var configuration = new OcelotPipelineConfiguration
            {
                PreAuthenticationMiddleware = async (ctx, next) =>
                {
                    if (xxxxxx) 
                    {
                        ctx.Errors.Add(new UnauthenticatedError("Your message"));
                        return;
                    }
                    await next.Invoke();
                }
            };

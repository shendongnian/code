        app.Use(async (context, next) =>
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await context.ChallengeAsync("Identity.Application");
            }
            else
            {
                await next();
            }
        });

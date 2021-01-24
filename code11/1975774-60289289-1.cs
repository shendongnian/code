     public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context == null) return Task.CompletedTask;
            // get the profile id from resource, passed in from the profile page 
            // component
            var resource = context.Resource?.ToString();
            var hasParsed = int.TryParse(resource, out int profileID);
            if (hasParsed)
            {
                // compare the requested profileID to the user's actual claim of 
                // profileID
                var isAuthorized = profileID == context.User.GetProfileIDClaim();
                -- --- I can't code blindly any more-----
            }
        }

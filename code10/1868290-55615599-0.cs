             return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api",
                    DisplayName = "WebApi API",
                    Scopes =
                    {
                        new Scope("WebApi.ReadAccess", "Read write access to web api")
                    
                    }
                },
				new ApiResource
                {
					Name = "api",
                    DisplayName = "WebApi API",
                    Scopes =
                    {
                        new Scope("WebApi.FullAccess", "Full access to web api")
                    
                    }
				}
            }
and 
o.Audience = "api";
The reason being,
Your o.Audience name should match ApiResource.Name because it indicates mapping between your authority and audience.
   For example in your case Authority https://localhost:44321 has audience lets say called "api".
   "api" also is a name of your ApiResource which is giving authority to create access token.
Hope this helps!

    services.AddAuthorization(opts =>
            {
                opts.AddPolicy(
              name: ConstantPolicies.DynamicPermission,
              configurePolicy: policy =>
              {
                  policy.RequireAuthenticatedUser();
                  policy.Requirements.Add(new DynamicPermissionRequirement());
              });
            });

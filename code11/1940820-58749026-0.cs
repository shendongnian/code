            services.AddControllersWithViews()
               .AddFluentValidation(options =>
                {
                   options.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
                   options.ImplicitlyValidateChildProperties = true;
                   options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

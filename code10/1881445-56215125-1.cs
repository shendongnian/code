    services.AddMvc(options => {
        options.Filters.Insert(0, new IgnoreAntiforgeryTokenAttribute());
        options.Filters.Add(typeof(WebApiExceptionFilter)); // by type
    });
    services.AddScoped<ValidateAntiforgeryTokenAuthorizationFilter, CustomValidateAntiforgeryTokenAuthorizationFilter > ();

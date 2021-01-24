    //..
    services.AddOptions();
    //Adds IOptions<InformationGetter>
    services.Configure<InformationGetter>(options => {
        options.ConnectionString = Configuration.GetSection("Model").GetSection("ConnectionString").Value;
        options.StoredProcedureName = "prInformationGetter";
    });
    //Adds InformationGetter but gets it from the registered options
    services.AddScoped<InformationGetter>(sp => 
        sp.GetRequiredService<IOptions<InformationGetter>>().Value
    );
    //...

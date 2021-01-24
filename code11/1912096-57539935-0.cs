    if(_environment.IsDevelopment())
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        });
    }
    else
    {
        // ...
    }

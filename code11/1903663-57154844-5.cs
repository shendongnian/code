    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IZLogger zLogger)
    {
        ...
        Log.Logger = zLogger.GetCurrentClassLogger<Startup>(); // Over-writing ASP.NET's ILogger with Serilog's ILogger from Core library
        app.UseSerilogRequestLogging(); // Added this line as per docs
        ...
    }

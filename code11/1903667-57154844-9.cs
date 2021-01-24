    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IZLogger zLogger)
    {
        ...
        Log.Logger = zLogger.GetCurrentClassLogger<Startup>(); // Set Serilog's ILogger from Core library
        app.UseSerilogRequestLogging(); // Added this line as per docs
        ...
    }

    services.AddApiVersioning(options => options.ReportApiVersions = true);
    services.AddMvcCore()
        .AddJsonFormatters()
        .AddVersionedApiExplorer(
              options =>
              {
                  ////The format of the version added to the route URL  
                  options.GroupNameFormat = "'v'VVV";
                  //Tells swagger to replace the version in the controller route  
                  options.SubstituteApiVersionInUrl = true;
              });

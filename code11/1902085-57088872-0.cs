    ...
    public IConfiguration Configuration { get; }
    private void SeedExampleData(IApplicationBuilder app)
    {
      var appArray = Configuration.GetSection("app").AsEnumerable();
      foreach (var item in appArray)
      {
        //TO DO
      }
    }

    [WebGet]
    public IEnumerable<Statistics> GetStats( DateTime startDate )
    {
        var stats = new Statistician();
        return ServiceHelper.WebServiceWrapper(startDate, stats.GetCompanyStatistics);
    }
    
    [WebGet]
    public IEnumerable<Statistics> GetStats( string startDate )
    {
      DateTime dt;
      if ( DateTime.TryParse( startDate, out dt) )
      {
        return GetStats( dt );
      }
      
      throw new WebFaultException<Result>(new Result() { Title = "Error",
        Description = "startDate is not of a valid Date format" },
        System.Net.HttpStatusCode.BadRequest);
    }

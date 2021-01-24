    var context = ApplicationDbContext.Create();
    try
    {
      var myRespository = new MyRepository(context);
      try
      {
        myRepository.ReadData();
      }
      finally
      {
        myRepository.Dispose();
      }
    }
    finally
    {
      context.Dispose();
    }

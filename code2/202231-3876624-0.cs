    List<Exception> es = new List<Exception>();
    while(e.InnerException != null)
    {
       es.add(e.InnerException);
       e = e.InnerException
    }

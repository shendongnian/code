    public MyResponse MyMethod(string arg)
    {
       MyResponse tmpResponse = null;
       MyResponse response = null;
       try
       {
           tmpResponse = new MyResponse();
    
           using (Tracer myTracer = new Tracer(Constants.TraceLog))
           {
               // Some code
           }
           response = tmpResponse;
           tmpResponse = null;
        }
        finally
        {
            if(tmpResponse != null)
                tmpResponse .Dispose();
        }
        return response;
    }

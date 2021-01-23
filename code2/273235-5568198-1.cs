    public MyResponse MyMethod(string arg)
    {
        MyResponse abc = null;
        try {
            abc = new MyResponse();
            using (Tracer myTracer = new Tracer(Constants.TraceLog))
            {
                // Some code
               return abc;
            }
        }
        catch {
            if (abc != null) {
                abc.Dispose();
            }
            throw;
        }
    }

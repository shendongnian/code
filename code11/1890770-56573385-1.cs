    {
        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(path), FileMode.Open, FileAccess.Read);
        try
        {
            // code inside the `using` goes here
        }
        finally
        {
            fs.Dispose();
        }
    }

    public static string GetUrl(string filename)
    {
        if (filename.StartsWith(context.Request.PhysicalApplicationPath))
        {
            return context.Request.ApplicationPath +     
                filename.Substring(context.Request.PhysicalApplicationPath.Length);
        }
        else 
        {
            throw new ArgumentException("Incorrect physical path");
        }
    }

    /// <summary>
    /// Set the page to not Cache
    /// </summary>
    protected void DontCache()
    {
        try
        {
            //Dont Cache
            Response.Expires = 0;
            Response.Cache.SetNoStore();
            Response.AppendHeader( "Pragma", "no-cache" );
        }
        catch ( Exception )
        {
            throw;
        }
    }

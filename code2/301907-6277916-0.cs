    public string GetVirtualPath( string physicalPath )
    {
       if ( !physicalPath.StartsWith( HttpContext.Current.Request.PhysicalApplicationPath ) )
       {
          throw new InvalidOperationException( "Physical path is not within the application root" );
       }
       return "~/" + physicalPath.Substring( HttpContext.Current.Request.PhysicalApplicationPath.Length )
             .Replace( "\\", "/" );
    }

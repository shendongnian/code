     Application_Error
     {
       HttpContext context = HttpContext.Current;
       Exception ex = context.Server.GetLastError();
      //process your exception
 
        if ( context.IsCustomErrorEnabled )
       {
          context.Server.ClearError();
          context.Server.Transfer( "~/error.aspx" );
       }
     }

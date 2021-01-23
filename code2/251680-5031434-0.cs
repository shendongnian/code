    try{
    
    ...
    ...
    }
    catch( Exception ex )
    {
     Exeception e = ex;
          while( e != null ){
           Response.Write (e.ToString());
           Response.Write("<HR>");
           e = e.InnerException;
          }
    }
    
    }

     try 
        {
          HttpContext.Current.Response.Write(strHTMLContent);
          HttpContext.Current.Response.End();
        }
     catch(Exception ex)
        {
          //handle exception
         }
     finally
         {
           this.Page.Response.Redirect("http://www.google.com");
         }

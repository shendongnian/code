    public interface IOpenAuthRedirect
    {
          public void Redirect( url )
          public void ParseCallback( url )
    }
    public class MVCOpenAuthRedirect
    {
         public void Redirect(url)
         {
            HttpContext.Current.Response.Redirect(url);
         }
    }
    public class SilverlightOpenAuthRedirect
    {
        public void RedirectUrl( url )
        {
            SomeBrowserControl.IForgetTheCallToRedirect( url );
        }   
    }

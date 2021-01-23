    namespace SomeNamespace
    {
       using System.Web.UI;
    
       public class SqlBasedSession
       {
          public SqlBasedSession(Page webPage)
          {
             webPage.Unload += new EventHandler(webPage_Unload);
          }
    
          void webPage_Unload(object sender, EventArgs e)
          {
             // the web page is being unloaded so this class can
             // cleanup it's resources now
          }
       }
    }

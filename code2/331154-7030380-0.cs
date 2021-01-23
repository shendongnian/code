    //a basepage that overrides the methods
    public class BasePage : System.Web.UI.Page
    
      protected override void SavePageStateToPersistenceMedium(object state)
      {
      }
      protected override object LoadPageStateFromPersistenceMedium()
      {
          return null;
      }
    
    end class
    
    //your page class that inherits your base page
    public class Page1 : BasePage
    end class

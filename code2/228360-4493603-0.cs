    public class BasePage : Page
    {
      public BasePage()
      {
        this.PreInit += new EventHandler(BasePage_PreInit);
      }
    
      protected void BasePage_PreInit(object sender, EventArgs e)
      {
        this.Page.Theme = theme; //Garner from appropriate resource
      }
    }

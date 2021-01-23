    public class MyUserControl : System.Web.UI.UserControl {
      public string MyTextBoxValue()
      {
        get 
        {
          return MyTextBoxControl.Text;
        }
      }
    }

    public class BusinessLayer {
      private Login _login;
      public BusinessLayer(Login login) {
        _login = login;
      }
    }
    
    public partial class Login : System.Web.UI.Page() {
      public void Method() {
        BusinessLayer layer = new BusinessLayer(this);
        ...
      }
    }

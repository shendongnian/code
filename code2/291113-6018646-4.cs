    namespace JWC.Examples.WebForms {
       public partial class _Default : BasePage {
          protected void Page_Load(object sender, EventArgs e) {
             if (Session["SomeItem"] == null)
                Session["SomeItem"] = 42;
          }
       }
    }

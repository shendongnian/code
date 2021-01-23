    public abstract partial class BasePage: System.Web.UI.Page
    {
        public bool IsSecure { get; set; }
        protected override void OnInit(EventArgs e)
        {
            if (!IsSecure) return;
            if (PageMaster == null)
                return;
            if (!PageMaster.IsUserLoggedIn)
            {
                HttpContext.Current.Response.Redirect("~/WebForms/LogIn.aspx");
            }
            base.OnInit(e)
        }  
    }
    public partial class _Default : BasePage
    {   
       protected void Page_PreInit(object sender, EventArgs e)
       {
          IsSecure = true;
       }
    }

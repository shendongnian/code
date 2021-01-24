    I removed the last three statements above and added two other lines in their place so i now have below:
    public partial class Account : System.Web.UI.Page
    {
    public string Description { get; internal set; }
    public string Quantity { get; internal set; }
    public string Price { get; internal set; }
    public string Value { get; internal set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated)
        {
         StatusText.Text = string.Format("Hello {0}!! ", User.Identity.GetUserName(), Description, Quantity, Price, Value);                                         
         LoginStatus.Visible = true;
         LogoutButton.Visible = true;
            }
            else
            {
                LoginForm.Visible = true;
            }
        }
        var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>  ().FindById(User.Identity.GetUserId());
        Response.Write(user.Description + "" + user.Quantity + "" + user.Price + "" + user.Value);
    }
}
    I have not run it yet but all the parameters were accepted in development.

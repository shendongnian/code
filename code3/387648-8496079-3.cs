    public partial class MyLoginControl : Control
    {
        ...
        protected void Page_PreRender(object sender, EventArgs e)
        {
            RequredValidator1.ValidationGroup = this.ID + "ValidationGroup";
        }
        ...
    }

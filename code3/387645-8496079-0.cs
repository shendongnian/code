    public partial class MyLoginControl : Control
    {
        ...
        public string ValidationGroup
        {
            get; set;
        }
        ...
        protected void Page_PreRender(object sender, EventArgs e)
        {
            RequredValidator1.ValidationGroup = this.ValidationGroup;
        }
        ...
    }

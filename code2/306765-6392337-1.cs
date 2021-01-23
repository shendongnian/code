    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddedControl();
        }
    
        protected Label myLabel = new Label();
        void AddedControl()
        {
            myLabel.Text = "Labelll";
            this.pnl.Controls.Add(myLabel);
        }
    }

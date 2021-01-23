    public partial class UCGroup : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public List<string> Recipients { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbltitle.Text = Title;
            this.rpRecipients.DataSource = Recipients;
            this.rpRecipients.DataBind();
        }
    }

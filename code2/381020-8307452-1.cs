    public partial class _Default : System.Web.UI.Page
    {
        public string scriptPostBackButton1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                scriptPostBackButton1 = 
                    ClientScript.GetPostBackEventReference(new PostBackOptions(clickableButton, "", "", false, false, true, true, true, ""));
            }
        }
        protected void clickableButton_Click(object sender, EventArgs e)
        {
            string result = "ok, it's working";            
        }
    }

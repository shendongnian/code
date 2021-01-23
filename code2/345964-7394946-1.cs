    public partial class ucTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucBottom.varBottomID = 100;
        }
    }
    
    
    public partial class ucBottom : System.Web.UI.UserControl
    {
        public int varBottomID { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            BottomText.Text = Convert.ToUInt32(varBottomID).ToString();
        }
    }

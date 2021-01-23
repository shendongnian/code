    public partial class _Default : Page
    {
        protected void Page_Load(sender obj, EventArgs e)
        {
            ucBottom.varBottomID = ucTop.varBottomID;  // Fix the first issue
        }
    }
    public partial class ucTop : UserControl
    {
         public int varBottomID { get; set; } // fix the second issue
         protected void Page_Load(object src, EventArgs e)
         {
             varBottomID = 100;
         }
    }

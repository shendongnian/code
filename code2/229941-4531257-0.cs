        public partial class expt2 : System.Web.UI.Page
    {
        double result ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                  Session["result"] = 0.0;
        }
     protected void Chkbxbd_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkbxbd.Checked)
            {
                txtbxttl.Text = "" + 10000;
                result = double.Parse(Session["result"].ToString());
                result += double.Parse(txtbxttl.Text);
                Session["result"] = result;
    
            }
            else
            {
                 result = double.Parse(Session["result"].ToString());
                 result = result - 10000;
                 Session["result"]= result;
            }
               
           
           
          }
        protected void Chkbxsfa_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkbxsfa.Checked)
            {
                txtbxttl.Text = "" + 15000;
                result = double.Parse(Session["result"].ToString());
                result += double.Parse(txtbxttl.Text);
                Session["result"] = result;
            }
            else
            {
                result = double.Parse(Session["result"].ToString());
                result = result - 15000;
                Session["result"] = result;
            }
               
            
            
        }
     protected void btnttl_Click(object sender, EventArgs e)
        {
            txtbxttl.Text = "" + Session["result"].ToString();
    
        }
    }
  

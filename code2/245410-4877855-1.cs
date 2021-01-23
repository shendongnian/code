    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void butRaiseEvent_Click(object sender, EventArgs e)
        {
            CheckSub(this.Parent.Parent.Controls);
        }
    
        private void CheckSub(ControlCollection cc)
        {
            foreach (Control c in cc)
            {
                if (c is IBinder)
                    ((IBinder)c).Bind();
                else
                    CheckSub(c.Controls);
            }
        }
    }

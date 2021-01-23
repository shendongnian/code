    public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                
            }
    
            protected void Page_Init(object sender, EventArgs e)
            {
                CreateControls();
            }
    
            private void CreateControls()
            {
                var lb = new LinkButton();
                lb.Text = "Click Me";
                lb.Click += lb_Click;
    
                ph.Controls.Add(lb);
                ph.DataBind();
            }
    
            void lb_Click(object sender, EventArgs e)
            {
                lblMessage.Text = "Button is clicked!"; 
            }
        }

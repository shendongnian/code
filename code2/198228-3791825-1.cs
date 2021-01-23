    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace VS2010WEBFORMS
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            Button SubmitButton = new Button();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                SubmitButton.Text = "Submit";
                SubmitButton.Click += new EventHandler(SubmitButton_Click);
                form1.Controls.Add(SubmitButton);
            }
    
            private void SubmitButton_Click(object sender, EventArgs e)
            {
                //Something
            }
        }
    }

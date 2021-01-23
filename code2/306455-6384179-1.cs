    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class HideTextFields : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in form1.Controls)
            {
                if (c is TextBox)
                    c.Visible = false;
                    
            }
        }
    }

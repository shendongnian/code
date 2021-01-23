       protected void Button1_Click(object sender, EventArgs e)
        {
            ReSetToDefault();
        }
        private void ReSetToDefault()
        {
            ResetControl(this.Page.Controls);
        }
        private void ResetControl(ControlCollection controlCollection)
        {
            foreach (Control con in controlCollection)
            {
                if (con.Controls.Count > 0)
                    ResetControl(con.Controls);
                else
                {
                    switch (con.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            {
                                TextBox txt = con as TextBox;
                                txt.Text = "default value";
                            }
                            break;
                        case "System.Web.UI.WebControls.CheckBox"
                            {
                            }
                            break;
                    }
                }
            }
        }

        public static void DisableAllChildServerControls(Control ctrl, bool disable)
        {
            foreach(Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = c as TextBox;
                    t.Enabled = !disable;
                    if (t.ID == "txtRefundedAmount")
                        t.Enabled = true;
                }
                else if (c is DropDownList)
                {
                    DropDownList d = c as DropDownList;
                    d.Enabled = !disable;
                }
                else if (c is Button)
                {
                    Button b = c as Button;
                    b.Enabled = !disable;
                }
                if(c.Controls.Count > 0)
                {
                    DisableAllChildServerControls(c, disable);
                }
            }
        }

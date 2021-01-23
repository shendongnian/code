            foreach (Control c in UpdatePanel1.Controls)
            {
                foreach (Control c1 in c.Controls)
                {
                    if (c1 is TextBox)
                    {
                        TextBox txtBox = (TextBox)c1;
                        txtBox.Text = "0";
                    }
                }
            }

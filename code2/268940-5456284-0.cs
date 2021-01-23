     foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ReadOnly = true;
                    }
                }

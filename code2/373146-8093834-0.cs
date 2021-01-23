    foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.Text = "MyButton" + (c.TabIndex + 1);
                    }
                }

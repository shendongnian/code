    foreach(Control c in this.panel1.Controls)
            {
                if (c.GetType() == typeof(TextBox) && c.Text != String.Empty)
                {
                    decimal myValue = Convert.ToDecimal(c.Text);
                }
            }

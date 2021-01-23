    int i = ((TextBox)sender).SelectionStart;
            if (((TextBox)sender).Text != "")
            {
                string f = String.Format("{0:N0}", Convert.ToDouble(((TextBox)sender).Text));
                ((TextBox)sender).Text = f;
                int len;
                len = textBox1.Text.Replace(",", "").Length;
                if ((len %= 3) == 1)
                {
                    i += 1;
                }
                ((TextBox)sender).SelectionStart = i;
            }

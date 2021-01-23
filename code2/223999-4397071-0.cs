          private void txtAmount_Leave(object sender, EventArgs e)
        {
            string strAmnt = string.Empty;
            strAmnt = txtAmount.Text;
            if (strAmnt.Contains(".") && !strAmnt.Contains("$"))
            {
                txtAmount.Text = "$" + strAmnt;
                while (txtAmount.Text.Length - txtAmount.Text.IndexOf(".") <= 2)
                {
                    txtAmount.Text += "0";
                }
            }
            else
                if (strAmnt.Contains("$") && !strAmnt.Contains("."))
                {
                    Int64 amnt = 0;
                    strAmnt = strAmnt.Replace("$", "");
                    try
                    {
                        amnt = Convert.ToInt64(strAmnt);
                        double amt = (double)amnt / 100;
                        txtAmount.Text = "$" + amt.ToString();
                    }
                    catch (FormatException ie)
                    {
                        MessageBox.Show("Invalid Format");
                    }
                }
                else
                    if (!strAmnt.Contains(".") && !strAmnt.Contains("$"))
                    {
                        try
                        {
                            int x = Convert.ToInt32(txtAmount.Text);
                            double res = (double)x / 100;
                            txtAmount.Text = "$" + res.ToString();
                            while (txtAmount.Text.Length - txtAmount.Text.IndexOf(".") <= 2)
                            {
                                txtAmount.Text += "0";
                            }
                        }
                        catch (FormatException ie)
                        {
                            MessageBox.Show("InvalidFormat");
                        }
                    }
            while (txtAmount.Text.Length - txtAmount.Text.IndexOf(".") <= 2)
            {
                txtAmount.Text += "0";
            }
        }

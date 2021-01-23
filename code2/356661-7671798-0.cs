     private string text
            {
                get
                {
                    return text;
                }
                set
                {
                    try
                    {
                        string temp = string.Empty;
                        for (int i = 0; i < value.Length; i++)
                        {
                            int p = (int)value[i];
                            if (p >= 48 && p <= 57)
                            {
                                temp += value[i];
                            }
                        }
                        value = temp;
                        myTxt.Text = value;
                    }
                    catch
                    { 
    
                    }
                }
            }
        private void digitTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (myTxt.Text == "")
                return;
            int n = myTxt.SelectionStart;
            decimal text = Convert.ToDecimal(myTxt.Text);
            myTxt.Text = String.Format("{0:#,###0}", text);
            myTxt.SelectionStart = n + 1;
        }

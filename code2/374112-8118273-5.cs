            if (IsPostBack) 
            {
                if (TextBox1.Text.Length > 0) 
                {
                    if (TextBox1.Text.IndexOf('.') == -1)
                    {
                        TextBox1.Text = TextBox1.Text + ".00";
                    }
                    else if (TextBox1.Text.EndsWith(".")) 
                    {
                        TextBox1.Text = TextBox1.Text + "00"; 
                    }
                    else 
                    {
                        for (int i = 0; i <= 9; i++) 
                        {
                            if (TextBox1.Text.EndsWith("." + i)) 
                            {
                                TextBox1.Text = TextBox1.Text + "0";
                            }
                        }
                    }
                }
            } 

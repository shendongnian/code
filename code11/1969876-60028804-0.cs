    foreach (Control contr in tableLayoutPanel1.Controls)
            {
                if (contr is RichTextBox)
                {
                    if ((contr as RichTextBox).Text == string.Empty)
                    {
                        contr.Text = str_product;
                    }
                }
                  
            }

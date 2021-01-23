    private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    if(textBox1.Text == "Andrea")
                    {
                        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
                    }
                    else if(textBox1.Text == "Brittany")
                    {
                        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
                    }
    
                    MessageBox.Show("The spelling of the name is incorrect", "Bad Spelling");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Bad Spelling");
                }
            }
        }
    }

     private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (!(e.KeyCode == Keys.Back))
                {
                    string text = textBox1.Text.Replace(",", "");
                    if (text.Length % 3 == 0)
                    {
                        textBox1.Text += ",";
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                }
            }

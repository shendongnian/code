            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            { 
            }
            else
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                MessageBox.Show("Enter only Alphabets");
              
            }

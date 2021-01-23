     Regex regex = new Regex("^[ace-z]{5}$");
        if (regex.IsMatch(textBox1.Text))
        {
            errorProvider1.SetError(textBox1, String.Empty);
        }
        else
        {
            errorProvider1.SetError(textBox1, 
                  "Invalid entry");
        }

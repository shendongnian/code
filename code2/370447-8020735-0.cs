       private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            double doubleresult = 0;
            bool result = Double.TryParse(textBox1.Text, out doubleresult);
            if (result)
            {
                errorProvider1.SetError(textBox1, string.Empty);
            }
            else
            {
                errorProvider1.SetError(textBox1, "Must be a Double");
                e.Cancel = true;
            }
        }

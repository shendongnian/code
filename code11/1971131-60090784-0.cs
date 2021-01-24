    List<string> errors = new List<string>();
    if (string.IsNullOrEmpty(textBox1.Text))
    {
        errors.Add("User Field Is Empty");
    }
    if (string.IsNullOrEmpty(textBox2.Text))
    {
        errors.Add("Document Reference Code Field Is Empty");
    }
    if(errors.Count > 0)
    {
        string message = string.Join(Environment.NewLine, errors);
        MessageBox.Show(message);
    }

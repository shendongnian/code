    List<string> errors = new List<string>();
    if (string.IsNullOrEmpty(textBox1.Text))
    {
        errors.Add("User");
    }
    if (string.IsNullOrEmpty(textBox2.Text))
    {
        errors.Add("Document Reference Code");
    }
    if(errors.Count > 0)
    {
        errors.Insert(0, "The following fields are empty:");
        string message = string.Join(Environment.NewLine, errors);
        MessageBox.Show(message);
    }

    List<string> values = new List<string>();
    foreach(Control c in this.Controls)
    {
        if(c is TextBox)
        {
            values.Add(c.Text);
        }
    }
    string[] array = values.ToArray();

     List<string> textboxes = new List<string>();
    
             foreach (Control c in this.Controls)
             {
                if (c is TextBox)
                {
                   textboxes.Add((TextBox)c.text);
                }
             }

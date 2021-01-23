     List<string> textboxes = new List<string>();
    
             foreach (Control c in this.Controls)
             {
                if (c is TextBox)
                {
                   textboxes.Add(((TextBox)c).Text); //oops.. forgot a set of parenthesis had to come back and edit.
                }
             }

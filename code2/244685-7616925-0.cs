    int numControls = Page.Form.Controls.Count;
        
        for (int i = 0; i < numControls; i++)
        {
            if (Page.Form.Controls[i] is TextBox)
            {
                TextBox currBox = Page.Form.Controls[i] as TextBox;
                currbox.Text = currbox.TabIndex.ToString();
            }
        }

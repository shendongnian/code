        foreach (Control c in panel.Controls)
        {
            if (c.GetType().Name == "TextBox")
            {
                c.Text = "";
            }
        }

    public void FindAllTextBox(Control ctrl)
    {
        if (ctrl != null)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = string.empty;
                FindAllTextBox(c);
            }
        }
    }

    protected void buttonClick(object sender, EventArgs e)
    {
        List<String> errors = new List<String>();
        ValidateTextboxes(errors, this.Controls);
        if (errors.Count > 0)
        {
            // Validation failed
        }
    }
    protected void ValidateTextboxes(List<String> errors, ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox)
            {
                // Validate
                TextBox tb = control as TextBox;
                if (tb.Text.Length == 0)
                    errors.Add(tb.ID + ": field is required:");
            }
    
            if (control.Controls.Count > 0)
                ValidateTextboxes(errors, control.Controls);
        }
    }

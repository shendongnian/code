    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        Control control = ActiveControl as TextBox;
        if (control != null) // Safety check
        {
            if (keyData == Keys.Enter)
            {
                // Check if next control is a text-box and send focus to it.
                Control nextControl = GetNextControl(control, true);
                if (nextControl is TextBox)
                {
                    SelectNextControl(control, true, true, false, false);
                }
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

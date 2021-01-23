    if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
    {
        MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
    }
    else
    {
        MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
    }

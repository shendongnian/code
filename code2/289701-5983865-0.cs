    private void formControl_KeyModified(object sender, KeyEventArgs e)
    {
        char c = (char)e.KeyCode;
        if (Char.IsLetterOrDigit(c)) {
            // useful
        }
        // might add more checks
        // else if (Char.IsPunctuation(c)) ...
    }

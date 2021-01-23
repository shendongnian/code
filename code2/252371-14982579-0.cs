    protected override bool ProcessCmdKey(ref Message message, Keys keys)
    {
        switch (keys)
        {
            case Keys.B | Keys.Control | Keys.Alt | Keys.Shift:
                // ... Process Shift+Ctrl+Alt+B ...
                return true; // signal that we've processed this key
        }
        // run base implementation
        return base.ProcessCmdKey(ref message, keys);
    }

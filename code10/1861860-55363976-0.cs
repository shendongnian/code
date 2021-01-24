    private void ApplyChanges(Control ctrl)
    {
        foreach (Control c in ctrl.Controls)
        {
            // Do something
    
            Debug.WriteLine($"ctrl name: {c.Name}"); // Test code, just to print the control name(s).
            if (c.Controls != null && c.Controls.Count > 0)
            {
                ApplyChanges(ctrl);
            }
        }
    }

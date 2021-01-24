    private void DisableAutoSize()
    {
        foreach (Label control in Controls.OfType<Label>().Where(c => !c.Name.Contains("Label")))
        {
             control.AutoSize = false;
        }
    }

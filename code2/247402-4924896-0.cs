    void UpdateFinishEnabled()
    {
        var boxes = new CheckBox[] { checkBlinna, checkSoup, checkGnocchi };
        btnFinish.Enabled = boxes.Any(b => b.Checked);
    }

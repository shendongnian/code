    private void CheckChanged(object sender, EventArgs e)
    {
        var boxes = new CheckBox[] { checkBlinna, checkSoup, checkGnocchi };
        btnFinish.Enabled = boxes.Any(b => b.Checked);
    }

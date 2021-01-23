    private void CleanForm()
    {
        traverseControlsAndSetTextEmpty(this.Controls);
    }
    private void traverseControlsAndSetTextEmpty(List<Control> controls)
    {
        if (controls == null) return;
        foreach(var c in controls.Controls)
        {
            if (c is TextBox) ((TextBox)c).Text = String.Empty;
            traverseControlsAndSetTextEmpty(c.Controls);
        }
    }

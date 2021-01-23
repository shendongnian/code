    private void CleanForm()
    {
        traverseControlsAndSetTextEmpty(this);
    }
    private void traverseControlsAndSetTextEmpty(Control control)
    {
        
        foreach(var c in control.Controls)
        {
            if (c is TextBox) ((TextBox)c).Text = String.Empty;
            traverseControlsAndSetTextEmpty(c);
        }
    }

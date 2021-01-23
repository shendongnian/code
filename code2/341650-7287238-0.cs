    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Alt && e.KeyCode == Keys.A)
        {
            toolStripDropDownButton1.ShowDropDown();
        }
        base.OnKeyDown(e);
    }

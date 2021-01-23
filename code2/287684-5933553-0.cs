    // (in the form initialization code)
    btn.EnabledChanged += UpdateButtons;
    btn1.EnabledChanged += UpdateButtons;
    //...
    private void UpdateButtons(object sender, EventArgs args)
    {
         bt3.Enabled = !btn.Enabled && !btn1.Enabled;
    }

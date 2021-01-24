    private Button _activeButton = null;
    private void ButtonClickHandler(object sender, EventArgs e)
    {
        // disable previosly active button
        if (_activeButton != null) _activeButton.BackColor = Color.Lavender;
        // set new button
        _activeButton = sender as Button;
        // enable currently active button
        if (_activeButton != null) _activeButton.BackColor = Color.Green;
    }

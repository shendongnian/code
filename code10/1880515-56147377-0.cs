    private void ButtonClickHandler(object sender, EventArgs e)
    {
        // iterate over all buttons on form
        foreach (var button in Controls.OfType<Button>())
            button.BackColor = button == sender ? Color.Green : Color.Lavender;
    }

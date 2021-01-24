    private void jTextBox9_TextChangeEvent(object sender, EventArgs e)
    {
        bool containsDisallowedChar = false;
        foreach (char c in jTextBox9.TextValue.ToLower()) {
            if (!eng.Contains(c)) {
                containsDisallowedChar = true;
                break; // Exit the loop.
            }
        }
        if (containsDisallowedChar) {
            label23.Text = "This Field has to be in English";
            label23.Visible = true;
        } else {
            label23.Visible = false;
        }
    }

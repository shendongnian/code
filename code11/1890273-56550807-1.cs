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
            if (!jTextBox9.Focused) { // In case text is changed in code.
                jTextBox9.Focus();
            }
        } else {
            label23.Visible = false;
        }
    }

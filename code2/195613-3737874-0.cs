        List<string> getSuggestions(string text)
        {
            System.Windows.Controls.TextBox wpfTextBox = new System.Windows.Controls.TextBox();
            wpfTextBox.AcceptsReturn = true;
            wpfTextBox.AcceptsTab = true;
            wpfTextBox.SpellCheck.IsEnabled = true;
            wpfTextBox.Text = text;
            int index = 0;
            List<string> suggestions = new List<string>();
            while ((index = wpfTextBox.GetNextSpellingErrorCharacterIndex(index, System.Windows.Documents.LogicalDirection.Forward)) != -1)
            {
                string currentError = wpfTextBox.Text.Substring(index, wpfTextBox.GetSpellingErrorLength(index));
                suggestions.Add(currentError);
                foreach (string suggestion in wpfTextBox.GetSpellingError(index).Suggestions)
                {
                    suggestions.Add(suggestion);
                }
            }
            return suggestions;
        }

    <pre><code> 
        // Save last successful match.
        private int lastMatch = 0;
        // textBoxSearch - where the user inputs his search text
        // listBoxSelect - where we searching for text
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Index variable.
            int x = 0;
            // Find string or part of it.
            string match = textBoxSearch.Text;
            // Examine text box length 
            if (textBoxSearch.Text.Length != 0)
            {
                bool found = true;
                while (found)
                {
                    if (listBoxSelect.Items.Count == x)
                    {
                        listBoxSelect.SetSelected(lastMatch, true);
                        found = false;
                    }
                    else
                    {
                        listBoxSelect.SetSelected(x, true);
                        match = listBoxSelect.SelectedValue.ToString();
                        if (match.Contains(textBoxSearch.Text))
                        {
                            lastMatch = x;
                            found = false;
                        }
                        x++;
                    }
                }
            }
        }
    </pre></code>

    private void tokenize(PlaceHolder ph, string str)
    {
        int index = str.IndexOf('@') + 1;
        
        if (index == 0)
        {
            ph.Controls.Add(new Label { Text = str });
            return;
        }
        ph.Controls.Add(new Label { Text = str.Substring(0, index - 1) });
        if (Tokens.Keys.Any(k => str.Substring(index).StartsWith(k + "@")))
        {
            int next = str.IndexOf("@", index);
            string key = str.Substring(index, next - index);
            ph.Controls.Add(new TextBox
            {
                ID = "txt" + key,
                Text = Tokens[key],
                TextMode = TextBoxMode.MultiLine,
                Rows = 2
            });
            index = next + 1;
        }
        
        tokenize(ph, str.Substring(index));
    }

     private void RemoveAndReplaceSpecialCharacters(string input)
        {
            Regex.Replace(input, @"[\\\/]+", "-");
                Regex.Replace(input, @"[^0-9a-zA-Z\._]+", string.Empty);
        }

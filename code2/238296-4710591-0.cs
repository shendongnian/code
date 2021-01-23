            textbox.Text = string.Empty;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains("thumbnail:example.com") && lines[i].Contains("name:"))
                {
                    lines[i] = lines[i].Insert(lines[i].IndexOf(' '), " thumbnail:example.com");
                }
            }
            textbox.Text = string.Join(Environment.NewLine, lines);

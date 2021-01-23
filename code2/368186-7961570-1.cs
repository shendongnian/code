            string[] lines = list.Lines;
            string line;
            int len = 0;
            for (int i = 0, max = lines.Length; i < max; i++)
            {
                line = lines[i];
                int j = i == 0 ? 0 : len;
                string str = Regex.Match(line, @"#.*$").Value;
                if (!string.IsNullOrEmpty(str))
                {
                    int start = list.Find(str, j, RichTextBoxFinds.None);
                    if (start != -1)
                    {
                        list.Select(start, str.Length);
                        list.SelectionColor = Color.Red;
                    }
                    len += line.Length;
                }
            }

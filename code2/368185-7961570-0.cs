        string[] lines = list.Lines;
        string line;
        for (int i = 0, max = lines.Length; i < max; i++)
        {
            line = lines[i];
            int j = i == 0 ? 0 : i + lines[i - 1].Length;
            int start = list.Find("#", j, RichTextBoxFinds.NoHighlight);
            int end = list.Find(" ", j, RichTextBoxFinds.NoHighlight);
            if (-1 != start || -1 != end)
            {
                list.Select(start, end - start);
                list.SelectionColor = color;
            }
        }

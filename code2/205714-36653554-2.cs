    List<string> WrapText(string text, int maxWidthInPixels, Font font)
    {
        string[] originalLines = text.Split(new string[] { " " }, StringSplitOptions.None);
        List<string> wrappedLines = new List<string>();
        StringBuilder actualLine = new StringBuilder();
        int actualWidth = 0;
        foreach (var item in originalLines)
        {
            Size szText = TextRenderer.MeasureText(item, font);
            actualLine.Append(item + " ");
            actualWidth += szText.Width;
            if (actualWidth > maxWidthInPixels)
            {
                wrappedLines.Add(actualLine.ToString());
                actualLine.Clear();
                actualWidth = 0;
            }
        }
        if (actualLine.Length > 0)
            wrappedLines.Add(actualLine.ToString());
        return wrappedLines;
    }

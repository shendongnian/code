    static List<string> WrapText(string text, double pixels, Font font)
    {
    string[] originalLines = text.Split(new string[] { " " }, 
        StringSplitOptions.None);
    List<string> wrappedLines = new List<string>();
    StringBuilder actualLine = new StringBuilder();
    double actualWidth = 0;
    foreach (var item in originalLines)
    {
        int w = TextRenderer.MeasureText(item + " ", font).Width;
        actualWidth += w;
        if (actualWidth > pixels)
        {
            wrappedLines.Add(actualLine.ToString());
            actualLine.Clear();
            actualWidth = w;
        }
        actualLine.Append(item + " ");
    }
    if(actualLine.Length > 0)
        wrappedLines.Add(actualLine.ToString());
    return wrappedLines;
    }

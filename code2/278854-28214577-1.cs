    private bool WriteWord(string word)
    {
        Size size = TextRenderer.MeasureText(word + "  ", Font);
        if (cursor.X + size.Width > Width)
        {
            // you reached the end of the line
            return false;
        }
        cursor.X += size.Width;
        return true;
    }
    string[] tokens = text.Split(new string[] { " ", Environment.NewLine}); 
    int start = 0;
    string substring ="";
    foreach (var t in tokens)
    {
        if (!string.IsNullOrEmpty(t.Trim()))
        {
            if (!WriteWord(t))
                return substring;
            substring += t;
        }
    }

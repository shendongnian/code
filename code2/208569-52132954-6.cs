    private string StringLengthFormat(string inString, string longest)
    {
        Size textSizeMax = TextRenderer.MeasureText(longest, System.Drawing.SystemFonts.DefaultFont);
        Size textSizeCurrent = TextRenderer.MeasureText(inString, System.Drawing.SystemFonts.DefaultFont);
        do
        {
            inString = " " + inString;
            textSizeCurrent = TextRenderer.MeasureText(inString, System.Drawing.SystemFonts.DefaultFont);
        } while (textSizeCurrent.Width < textSizeMax.Width);
        return inString;
    }

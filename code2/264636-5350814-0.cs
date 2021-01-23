    FontStyle style = 0; // No styles
    is (isBold)
    {
        style |= FontStyle.Bold;
    }
    is (isItalic)
    {
        style |= FontStyle.Italic;
    }
    // etc

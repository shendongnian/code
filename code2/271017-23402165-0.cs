    public static void AppendText(this RichTextBox box, string text, string color)
    {
        BrushConverter bc = new BrushConverter();
        TextRange tr = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
        tr.Text = text;
        try 
        { 
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, 
                bc.ConvertFromString(color)); 
        }
        catch (FormatException) { }
    }

    ...
    TextRange selectionRange = new TextRange(this.richTextBox.Selection.Start, this.richTextBox.Selection.End);
    object selectedProperty = selectionRange.GetPropertyValue(TextBlock.TextDecorationsProperty);
    TextDecorationCollection textDecorationCollection = selectedProperty as TextDecorationCollection;
    if (textDecorationCollection != null)
    {
        foreach (TextDecoration textDecoration in textDecorationCollection)
        {
            if (textDecoration.Equals(TextDecorations.Underline))
            {
                // this code is never reached 
                selectedProperty = "Underline";
            }
            else if (textDecoration.Equals(TextDecorations.Strikethrough))
            {
                // this code is never reached 
                selectedProperty = "Strikethrough";
            }
        }
    }

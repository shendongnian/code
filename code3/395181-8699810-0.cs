    public static int GetCharacterIndexFromPoint(this TextBox textBox, Point point)
    {
        try {
            return Enumerable.Range(0, textBox.Text.Length).First(
                index => {
                    Rectangle rect = textBox.GetRectFromCharacterIndex(index, false);
                    rect.Union(textBox.GetRectFromCharacterIndex(index, true));
                    return rect.Contains(point);
                });
        } catch (InvalidOperationException) {
            // No character lies at specified point.
            return -1;
        }
    }

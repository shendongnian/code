    private Rectangle GetTextBounds(TextBox textBox, int startPosition, int length)
    {
      using (Graphics g = textBox.CreateGraphics())
      {
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        CharacterRange[] characterRanges = { new CharacterRange(startPosition, length) };
        StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
        stringFormat.SetMeasurableCharacterRanges(characterRanges);
        Region region = g.MeasureCharacterRanges(textBox.Text, textBox.Font,
                                                 textBox.Bounds, stringFormat)[0];
        Rectangle bounds = Rectangle.Round(region.GetBounds(g));
        Point textOffset = textBox.GetPositionFromCharIndex(0);
        return new Rectangle(textBox.Margin.Left + bounds.Left + textOffset.X,
                             textBox.Margin.Top + textBox.Location.Y + textOffset.Y,
                             bounds.Width, bounds.Height);
      }
    }

    TextBlock tb = new TextBlock();
    tb.Inlines.Add("Sample text with ");
    tb.Inlines.Add(new Run("bold") { FontWeight = FontWeights.Bold });
    tb.Inlines.Add(", ");
    tb.Inlines.Add(new Run("italic ") { FontStyle = FontStyles.Italic });
    tb.Inlines.Add("and ");
    tb.Inlines.Add(new Run("underlined") { TextDecorations = TextDecorations.Underline });
    tb.Inlines.Add("words.");

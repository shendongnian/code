    TextRange selectionRange = Editor.Selection as TextRange;
    selectionRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
    selectionRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
    selectionRange.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
    selectionRange.ApplyPropertyValue(Paragraph.LineHeightProperty, 45.0);
    selectionRange.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Right);

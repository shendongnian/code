    var para = richTextBox.CaretPosition.Paragraph;
    var range = new TextRange(para.ContentStart, para.ContentEnd);
    range.ApplyPropertyValue(TextElement.FontFamilyProperty, "Calibri");
    range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
    range.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);

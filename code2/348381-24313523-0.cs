    private bool NewInput;
    private void richTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (NewInput)
        {
            richTxt.BeginChange();
            TextPointer startPosition = richTxt.Selection.Start;
            Run r = new Run(e.Text, startPosition);
            if (IsSelectionBold)
            {
                r.FontWeight = FontWeights.Bold;
            }
            if (IsSelectionItalic)
            {
                r.FontStyle = FontStyles.Italic;
            }
            if (IsSelectionUnderlined)
            {
                r.TextDecorations = TextDecorations.Underline;
            }
            r.FontSize = double.Parse(SelectedFontHeight);
            r.FontFamily = new FontFamily(SelectedFont);
            richTxt.EndChange();
            NewInput = false;
            e.Handled = true;
            richTxt.CaretPosition = richTxt.CaretPosition.GetPositionAtOffset(1);
        }
    }

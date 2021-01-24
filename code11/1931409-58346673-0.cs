    RichTextBox txt;
	...
    bool suppressChanges = false;
    private void Txt_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!suppressChanges)
        {
            // suppress changes because changing highlights will trigger the event again
            suppressChanges = true;
            foreach (var change in e.Changes)
            {
                var changeStart = txt.Document.ContentStart.GetPositionAtOffset(change.Offset);
                TextRange changedRange;
                if (change.AddedLength > 0)
                    changedRange = new TextRange(changeStart, changeStart.GetPositionAtOffset(change.AddedLength));
                else
                    changedRange = new TextRange(changeStart, changeStart);
                SetRangeColors(changedRange);
            }
            //unsuppress changes
            suppressChanges = false;
        }
    }
    void SetRangeColors(TextRange range)
    {
        // Scan one line at a time starting with the beginning of the range
        TextPointer current = range.Start.GetLineStartPosition(0);
        while (current != null && current.CompareTo(range.End) < 0)
        {
            // find the next line or the end of the document
            var nextLine = current.GetLineStartPosition(1, out int lines);
            TextPointer lineEnd;
            if (lines > 0)
                lineEnd = nextLine.GetNextInsertionPosition(LogicalDirection.Backward);
            else
                lineEnd = txt.Document.ContentEnd;
            var lineRange = new TextRange(current, lineEnd);
            // clear properties first or the offsets won't match the characters
            lineRange.ClearAllProperties();
            var lineText = lineRange.Text;
            if (lineText.Length > 69)
            {
                var highlight = new TextRange(current.GetPositionAtOffset(70), lineEnd);
                highlight.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow);
            }
            // advance to the next line
            current = lineEnd.GetLineStartPosition(1);
        }
    }

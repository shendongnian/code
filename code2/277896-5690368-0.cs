    TextRange range = new TextRange(MyTextInput.Document.ContentStart, MyTextInput.Document.ContentEnd);
    range.Text = @"TOP a multiline text or file END";
    Regex reg = new Regex("(top|file|end)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
    var start = MyTextInput.Document.ContentStart;
    while (start != null && start.CompareTo(MyTextInput.Document.ContentEnd) < 0)
    {
        if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        {
            var match=reg.Match(start.GetTextInRun(LogicalDirection.Forward));
            
            var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward), start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
            textrange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Blue));
            textrange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            start= textrange.End; // I'm not sure if this is correct or skips ahead too far, try it out!!!
        }
        start = start.GetNextContextPosition(LogicalDirection.Forward);
    }

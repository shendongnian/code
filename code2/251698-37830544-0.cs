    public void SelectText(int offset, int length)
    {
        //Get the line number based off the offset.
        var line = textEditor.Document.GetLineByOffset(offset);
        var lineNumber = line.LineNumber;
        //Select the text.
        textEditor.SelectionStart = offset;
        textEditor.SelectionLength = length;
        //Scroll the textEditor to the selected line.
        var visualTop = textEditor.TextArea.TextView.GetVisualTopByDocumentLine(lineNumber);
        textEditor.ScrollToVerticalOffset(visualTop); 
    }

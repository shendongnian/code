                // position on end of control...
                richTextBox.UpdateLayout();
                richTextBox.ScrollToEnd();
                richTextBox.UpdateLayout();
                // ...then select text and it will be position on top of control.
                richTextBox.Focus();
                richTextBox.Selection.Select(foundRange.Start, foundRange.End);
                richTextBox.BringIntoView();

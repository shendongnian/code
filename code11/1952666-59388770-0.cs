    public void Fusion(ref Xceed.Wpf.Toolkit.RichTextBox pRichTextControl)
            {
                
                foreach (KeyValuePair<string, string> entry in LettreFusion)
                {
                    string keyword = entry.Key;
                    string newString = entry.Value;
    
                    TextRange text = new TextRange(pRichTextControl.Document.ContentStart, pRichTextControl.Document.ContentEnd);
                    TextPointer current = text.Start.GetInsertionPosition(LogicalDirection.Forward);
                    while (current != null)
                    {
                        string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                        if (!string.IsNullOrWhiteSpace(textInRun))
                        {
                            int index = textInRun.IndexOf(keyword);
                            if (index != -1)
                            {
                                TextPointer selectionStart = current.GetPositionAtOffset(index, LogicalDirection.Forward);
                                TextPointer selectionEnd = selectionStart.GetPositionAtOffset(keyword.Length, LogicalDirection.Forward);
                                TextRange selection = new TextRange(selectionStart, selectionEnd);
                                selection.Text = newString;
                                pRichTextControl.Selection.Select(selection.Start, selection.End);
                                pRichTextControl.Focus();
                            }
                        }
                        current = current.GetNextContextPosition(LogicalDirection.Forward);
                    }
                }
            }

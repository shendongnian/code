    private void flowDocumentReader1_KeyUp(object sender, KeyEventArgs e)
    {
        // Check for CTRL+C
        if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // Prevent duplicate processing
            BlockUIContainer lastBlockUIContainer = null;
            // Get start of selection
            TextPointer currentPointer = flowDocumentReader1.Selection.Start;
            // Process selected text
            while (currentPointer != null && currentPointer.GetOffsetToPosition(flowDocumentReader1.Selection.End) > 0)
            {
                // Check for BlockUIContainer
                BlockUIContainer blockUIContainer = currentPointer.GetAdjacentElement(LogicalDirection.Backward) as BlockUIContainer;
                if (blockUIContainer != null && blockUIContainer != lastBlockUIContainer)
                {
                    // Get text from Grid
                    Grid grid = blockUIContainer.Child as Grid;
                    if (grid != null)
                    {
                        string replacementText = String.Format("{0}\t{1}",
                            (grid.Children[0] as TextBlock).Text,
                            (grid.Children[1] as TextBlock).Text
                            );
                        stringBuilder.AppendLine(replacementText);
                    }
                    // GetAdjacentElement can return the container from multiple TextPointers, so only process once
                    lastBlockUIContainer = blockUIContainer;
                }
                else
                {
                    // Get text at current position
                    string text = currentPointer.GetTextInRun(LogicalDirection.Forward);
                    if (!String.IsNullOrEmpty(text))
                    {
                        stringBuilder.AppendLine(text);
                    }
                }
                // Move to next TextPointer
                currentPointer = currentPointer.GetNextContextPosition(LogicalDirection.Forward);
            }
            // Insert updated text to clipboard
            string newClipboardText = stringBuilder.ToString();
            Clipboard.SetData("Text", newClipboardText);
        }
    }

private void RichTextBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Get the paragraph block text
            var textBlock=RichTextBox.Document.Blocks.ElementAt(2);
            //get the caret position of the start of the paragraph
            var startOfTextBlock=textBlock.ContentStart;
            // get the the character rectangle
            Rect charRect = startOfTextBlock.GetCharacterRect(LogicalDirection.Forward);
            // set the the vertical offset ot the Y position of the rectangle 
            RichTextBox.ScrollToVerticalOffset(charRect.Y);
        }

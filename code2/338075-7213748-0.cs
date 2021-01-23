    private void AddInline(Inline inline)
    {
        var viewer = textBox.GetChildByType<ScrollViewer>(item => item.Name == "ContentElement") as ScrollViewer;
        bool scrollToBottom = viewer.VerticalOffset == viewer.ScrollableHeight;
        // Creating the paragraph isn't necessary.
        // In my own application, I only add a single paragraph to the RichTextBox that displays my chat messages.
        // Then I just add new Inlines to the single paragraph.
        Paragraph p = new Paragraph();
        p.Inlines.Add(inline);
        if (scrollToBottom)
            textBox.LayoutUpdated += ScrollRichTextBoxToBottom;
        // Adding the paragraph triggers a layout update.
        // In the LayoutUpdated handler, the viewer will be scrolled to the bottom, triggering a second layout pass.
        textBox.Blocks.Add(p);
    }
    
    private void ScrollRichTextBoxToBottom(object sender, EventArgs e)
    {
        // The LayoutUpdated handler needs to be removed, otherwise the RichTextBox becomes unscrollable.
        textBox.LayoutUpdated -= ScrollRichTextBoxToBottom;
        var viewer = textBox.GetChildByType<ScrollViewer>(item => item.Name == "ContentElement") as ScrollViewer;
        viewer.ScrollToVerticalOffset(viewer.ScrollableHeight);
    }

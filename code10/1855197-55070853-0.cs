    using (var contentStream = new MemoryStream())
    {
        TextRange range = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);
        range.Save(contentStream, DataFormats.XamlPackage);
        //rewind stream
        contentStream.Position = 0;
        TextRange range2 = new TextRange(RichTextBox2.Document.ContentStart, RichTextBox2.Document.ContentEnd);
        range2.Load(contentStream, DataFormats.XamlPackage);
    }

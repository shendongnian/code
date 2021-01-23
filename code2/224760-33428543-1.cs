    public static void ResizeRtbImages(RichTextBox rtb)
    {
        IEnumerable<Image> images = rtb.Document.Blocks<BlockUIContainer>()
                .Select(c => c.Child).OfType<Image>()
            .Union(rtb.Documents.Blocks.OfType<Paragraph>()
                .SelectMany(pg => pg.Inlines.OfType<InlineUIContainer>())
                .Select(inline => inline.Child).OfType<Image>()
            );
        foreach (var image in images)
        {
            // resize
        }
    }

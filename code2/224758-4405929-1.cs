        public static void ResizeRtbImages(RichTextBox rtb)
        {
            foreach (Block block in rtb.Blocks)
            {
                if (block is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)block;
                    foreach (Inline inline in paragraph.Inlines)
                    {
                        if (inline is InlineUIContainer)
                        {
                            InlineUIContainer uiContainer = (InlineUIContainer)inline;
                            if (uiContainer.Child is Image)
                            {
                                Image image = (Image)uiContainer.Child;
                                image.Width = image.ActualWidth + 1;
                                image.Height = image.ActualHeight + 1;
                            }
                        }
                    }
                }
            }
        }

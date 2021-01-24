<!-- -->
    public class ParagraphGroup : TextBase
    {
        public Paragraph[] Paragraphs { get; set; } = new Paragraph[0];
        public override string Text
        {
            get => String.Join(ParagraphSeparator, Paragraphs.Select(p => p.Text));
            set => Paragraphs =
                value.Split(new string[] { ParagraphSeparator }, StringSplitOptions.None)
                    .Select(s => new Paragraph { Text = s })
                    .ToArray();
        }
    }

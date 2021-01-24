<!-- -->
    public class Document : TextBase
    {
        public ParagraphGroup[] ParagraphGroups { get; set; } = new ParagraphGroup[0];
        public override string Text
        {
            get => String.Join(ParagraphGroupSeparator, ParagraphGroups.Select(g => g.Text));
            set => ParagraphGroups =
                value.Split(new string[] { ParagraphGroupSeparator }, StringSplitOptions.None)
                    .Select(s => new ParagraphGroup { Text = s })
                    .ToArray();
        }
    }

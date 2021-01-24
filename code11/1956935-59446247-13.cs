<!-- -->
    public class Paragraph : TextBase
    {
        public string[] Lines { get; set; } = new string[0];
        public override string Text
        {
            get => String.Join(LineSeparator, Lines);
            set => Lines = value.Split(new string[] { LineSeparator }, StringSplitOptions.None);
        }
    }

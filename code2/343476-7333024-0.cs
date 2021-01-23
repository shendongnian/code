    public class FileSizeContext
    {
        private string input;
        private int output;
        public FileSizeContext(string input)
        {
            this.Input = input;
        }
        public string Input { get; set; }
        public int Output { get; set; }
    }
    public abstract class FileSizeExpression
    {
        public abstract void Interpret(FileSizeContext value);
    }

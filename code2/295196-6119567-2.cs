    public class MyException : Exception
    {
        public TextBox TextBox { get; private set; }
        public MyException(TextBox textBox)
        {
            TextBox = textBox;
        }
    }

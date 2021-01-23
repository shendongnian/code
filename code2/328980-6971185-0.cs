    public class FixedStringBuilder
    {
        char[] buffer;
        public FixedStringBuilder(int length)
        {
            buffer = new string(' ', length).ToCharArray();
        }
        public FixedStringBuilder Replace(int index, string value)
        {
            value.CopyTo(0, buffer, index, value.Length);
            return this;
        }
        public override string ToString()
        {
            return new string(buffer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FixedStringBuilder sb = new FixedStringBuilder(100);
            string fieldValue = "12345";
            int startPos = 16; 
            sb.Replace(startPos, fieldValue);
            string buffer = sb.ToString();
        }
    }

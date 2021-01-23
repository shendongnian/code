    public interface IWriter
    {
        void Write(string text);
    }
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
           Console.WriteLine(text);
        }
    }
    public class StubWriter : IWriter
    {
        List<string> values = new List<string>();
        public void Write(string text)
        {
             values.Add(text);
        }
        public List<string> Values { get { return values; } }
    }

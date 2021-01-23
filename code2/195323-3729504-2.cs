    public interface ISomething
    {
        void SayHi();
    }
    public class Something : ISomething
    {
        public void SayHi() { Console.WriteLine("Hello World!"); }
        public void ISomething.SayHi() { Console.WriteLine("42!"); }
    }

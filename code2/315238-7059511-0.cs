    public interface IHello
    {
        void SayHello();
    }
    public class Hello : IHello
    {
        public void SayHello()
        {
            Console.WriteLine("Hello world!");
        }
    }

    public class Foo
    {
        private readonly int guessMe;
        public Foo()
        {
            Random rnd = new Random();
            guessMe = rnd.Next(0, 100);
        }
    }

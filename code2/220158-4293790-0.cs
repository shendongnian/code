    public class Disposable : IDisposable
    {
        private readonly string name;
        public Disposable(string name)
        {
            this.name = name;
        }
        public void Dispose()
        {
            Console.WriteLine("Disposing of {0}", name);
        }
    }

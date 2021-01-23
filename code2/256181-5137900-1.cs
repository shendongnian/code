    class Program
    {
        static void Main(string[] args)
        {
            using (MyClass c = new MyClass())
            {
                c.Disposed += MyClass_Disposed;
                Console.WriteLine("Press any key to dispose");
                Console.ReadKey();
            }
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }
        static void MyClass_Disposed(object source, EventArgs e)
        {
            Console.WriteLine("I've been disposed");
        }
    }
    class MyClass : IDisposable
    {
        public event EventHandler Disposed;
        public void Dispose()
        {
            if (this.Disposed != null)
                this.Disposed(this, EventArgs.Empty);
        }
    }

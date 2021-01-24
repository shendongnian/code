    class Program
    {
        [STAThread]
        static void Main()
        {
            Foo foo = new Foo();
            WeakReference fooRef = new WeakReference(foo);
            Console.WriteLine(fooRef.IsAlive); //Displays "True"
            foo = null;
            GC.Collect();
            Console.WriteLine(fooRef.IsAlive); //Displays "False"
            Console.ReadKey();
        }
    }  

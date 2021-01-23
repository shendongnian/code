    using System;
    class Program
    {
        void SomeMethod(object sender, EventArgs e) { }
        event EventHandler SomeEvent;
        static void Main(string[] args)
        {
            var prog = new Program();
    
            // Demonstrate that they are equivalent
            prog.SomeEvent += new EventHandler(prog.SomeMethod);
            prog.SomeEvent -= prog.SomeMethod; // Sugar for new EventHandler(prog.SomeMethod)
            Console.WriteLine("Number of SomeEvent subscribers is {0}", (prog.SomeEvent != null ? prog.SomeEvent.GetInvocationList() : new Delegate[0]).Length);
    
            // Why are they equivalent?
            var d1 = new EventHandler(prog.SomeMethod);
            var d2 = new EventHandler(prog.SomeMethod);
            Console.WriteLine("Delegates are reference equal {0}", Object.ReferenceEquals(d1, d2));
            Console.WriteLine("Delegates are equivalent {0}", d1 == d2);
        }
    }

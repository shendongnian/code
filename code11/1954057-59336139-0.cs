    using System;
    class Program
    {
        static void CreateDestructorReferences()
        {
            for (int i = 0; i < 1000; i++)
                _ = new Destructor();
        }
        static void CreateWithoutDestructorReferences()
        {
            for (int i = 0; i < 1000; i++)
                _ = new WithoutDestructor();
        }
        static void Main(string[] args)
        {
            CreateDestructorReferences();
            DemoGCProcess("****Objects With Destructors*****");
            CreateWithoutDestructorReferences();
            DemoGCProcess("****Objects Without Destructors*****");
            Console.ReadLine();
        }
    
        private static void DemoGCProcess(string text)
        {
            Console.WriteLine(text);
            var memory = GC.GetTotalMemory(false);
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            var memory1 = GC.GetTotalMemory(false);
            Console.WriteLine("Memory freed on first Garbage Collection on Generation 0:" + (memory - memory1));
            GC.Collect(1);
            var memory2 = GC.GetTotalMemory(false);
            Console.WriteLine("Memory freed on second Garbage Collection on Generation 0 and Generation 1:" + (memory1 - memory2));
        }
    }
    class Destructor
    {
    
        ~Destructor()
        {
            //Console.WriteLine("Destructor is called");
        }
    }
    class WithoutDestructor
    {
    
    }

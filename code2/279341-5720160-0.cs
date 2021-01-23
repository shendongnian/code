    class Program
    {
        static void Main()
        {
            // Warm-up
            Method1();
            Method2();
            Method3();
    
            const int Count = 1000000;
    
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < Count; i++)
            {
                Method1();
            }
            watch.Stop();
            Console.WriteLine("Method1: {0} ms", watch.ElapsedMilliseconds);
    
            watch = Stopwatch.StartNew();
            for (int i = 0; i < Count; i++)
            {
                Method2();
            }
            watch.Stop();
            Console.WriteLine("Method2: {0} ms", watch.ElapsedMilliseconds);
    
            watch = Stopwatch.StartNew();
            for (int i = 0; i < Count; i++)
            {
                Method3();
            }
            watch.Stop();
            Console.WriteLine("Method3: {0} ms", watch.ElapsedMilliseconds);
    
        }
    
        static void Method1()
        {
            string[] arrayOld = new[] { "This", "other", "aaa" };
            string[] arrayNew = new string[arrayOld.Length];
    
            for (var i = 0; i < arrayOld.Length; i++)
            {
                arrayNew[i] = arrayOld[i];
            }
        }
    
        static void Method2()
        {
            string[] arrayOld = new[] { "This", "other", "aaa" }; 
            var listNew = new List<string>();
    
            foreach(var val in arrayOld)
            { 
                listNew.Add(val); 
            } 
            string[] arrayNew = listNew.ToArray();    
        }
    
        static void Method3()
        {
            string[] arrayOld = new[] { "This", "other", "aaa" }; 
            string[] arrayNew = (from val in arrayOld select val).ToArray();    
        }
    }

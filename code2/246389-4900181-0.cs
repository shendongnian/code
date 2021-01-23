        Func<int, int> add = delegate(int x, int y)
                             {
                                 return x + y;
                             };
        Action<int> print = delegate(int x)
                            {
                                Console.WriteLine(x);
                            }
        Action<int> helloWorld = delegate // parameters can be ellided if ignored
                                 {
                                     Console.WriteLine("Hello world!");
                                 }

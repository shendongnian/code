    using System;
    using System.Diagnostics;
    
    struct BigStruct
    {
        public int value;
        #pragma warning disable 0169
        decimal a1, a2, a3, a4, a5, a6, a7, a8;
        decimal b1, b2, b3, b4, b5, b6, b7, b8;
        decimal c1, c2, c3, c4, c5, c6, c7, c8;
        decimal d1, d2, d3, d4, d5, d6, d7, d8;
        #pragma warning restore 0169
    }
    
    class Test
    {
        const int Iterations = 10000000;
        
        static void Main()
        {
            Time(NewVariableObjectInitializer);
            Time(ExistingVariableObjectInitializer);
            Time(NewVariableDirectSetting);
            Time(ExistingVariableDirectSetting);
        }
        
        static void Time(Func<int> action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Console.WriteLine("{0}: {1}ms",
                              action.Method.Name,
                              stopwatch.ElapsedMilliseconds);
        }
        
        static int NewVariableObjectInitializer()
        {
            int total = 0;
            for (int i = 0; i < Iterations; i++)
            {
                BigStruct b = new BigStruct { value = i };
                total += b.value;
            }
            return total;
        }
    
        static int ExistingVariableObjectInitializer()
        {
            int total = 0;
            BigStruct b;
            for (int i = 0; i < Iterations; i++)
            {
                b = new BigStruct { value = i };
                total += b.value;
            }
            return total;
        }
    
        static int NewVariableDirectSetting()
        {
            int total = 0;
            for (int i = 0; i < Iterations; i++)
            {
                BigStruct b = new BigStruct();
                b.value = i;
                total += b.value;
            }
            return total;
        }
    
        static int ExistingVariableDirectSetting()
        {
            int total = 0;
            BigStruct b;
            for (int i = 0; i < Iterations; i++)
            {
                b = new BigStruct();
                b.value = i;
                total += b.value;
            }
            return total;
        }
    }

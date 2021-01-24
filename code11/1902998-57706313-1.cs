    public class Benchmark
    {
        private MyClass[] data;
        
        private MyComparer<MyClass> linqComparer;
        
        private MyComparer<MyClass> nativeComparer;
        
        [Params(1000, 10000)]
        public int N;
        
        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();
            
            data = new MyClass[N];
            for (int i = 0; i < N; ++i)
            {
                data[i] = MyClass.Generate(random, N*10, 25);
            }
            
            // Compile order methods
            List<SortBy> sortBys = new List<SortBy>
            {
                new SortBy{PropName = "IntProp2", Ascending = true},
                new SortBy{PropName = "StrProp1", Ascending = false}
            };
            Func<MyClass, MyClass, int> sortMyClass = SortFuncCompiler.MakeSortFunc<MyClass>(sortBys);
            
            linqComparer = new MyComparer<MyClass>(sortMyClass);
            nativeComparer = new MyComparer<MyClass>(Sorters.SortOneIntOneStrHC);
        }
        
        [Benchmark]
        public MyClass[] Linq()
        {
            return data.OrderBy(x => x, linqComparer).ToArray();
        }
        
        [Benchmark]
        public MyClass[] Native()
        {
            return data.OrderBy(x => x, nativeComparer).ToArray();
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }

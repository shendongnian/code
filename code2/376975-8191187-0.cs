     class Foo : IEnumerable<int>
        {
            List<int> first = new List<int>();
            List<int> second = new List<int>();
    
    
            public Foo()
            {
                first.Add( 1 );
                first.Add( 2 );
               
                second.Add( 11 );
                second.Add( 12 );
            }
    
    
            public IEnumerator<int> GetEnumerator()
            {
                foreach (var f in first)
                {
                    yield return f;
                }
    
                foreach (var f in second)
                {
                    yield return f;
                } 
            }
        }
    
        static void Main(string[] args)
        {
            Foo f = new Foo();
    
            foreach (var d in f.Where(x => x % 2 == 0))
            {
                Console.WriteLine(d);
            }
    
    
            Console.ReadLine();
        }

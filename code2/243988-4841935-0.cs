        class Program
        {
            static int moo(int a)
            {
                for (int i = 2; i < a; i++)
                    if (a % i == 0)
                        return i;
    
                return a;
            }
    
            static void Main(string[] args)
            {
                List<int> a = new List<int>();
    
                for (int i = 0; i < 100; i++)
                    a.Add(moo(i));
    
                for (int i = 0; i < a.Count; i++)
                    Console.WriteLine("a[{0}] = {1}", i, a[i]);
            }
        }

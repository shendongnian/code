    namespace Indexers
    {
    
        class Demo
        {
            int[] a = new int[10];
    
    
            public int Lengths
            {
                get
                {
                    return a.Length;
                }
            }
    
    
            public int this[int index]
            {
                get
                {
                    return a[index];
                }
    
                set
                {
                    a[index] = value;
                }
            }
    
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                Demo d = new Demo();  // Notice here, this is a simple object
                                      //but you can use this like an array
    
                for (int i = 0; i < d.Lengths; i++)
                {
                    d[i] = i;
                }
    
                for (int i = 0; i < d.Lengths; i++)
                {
                    Console.WriteLine(d[i]);
                }
    
                 Console.ReadKey();
            }
        }
    }
    
    /*Output: 
    0
    1
    2
    3
    4
    5
    6
    7
    8
    9
    */

    using System;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                int[] x = new int[]{2,3,5};
                int[] y = new ArrayExpander().AddItem(x, 0);
    
                foreach (var i in y)
                {
                    Console.Write(i);
                }
            }
        }
    
        class ArrayExpander
        {
            public T[] AddItem<T>(T[] source, T item)
            {
                var destination = new T[source.Length + 1];
                Array.Copy(source, destination, source.Length);
                destination[source.Length] = item;
                return destination;
            }
        }
    }

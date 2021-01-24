    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace BubbleSort
    {
        class Program
        {
            static readonly Random rnd = new Random();
            static void Swap(IList<int> list, int indexA, int indexB)
            {
                int tmp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = tmp;
            }
            static void Main(string[] args)
            {
                var array = Enumerable.Range(1, 10).Select(r => rnd.Next(1,100)).ToList();
    
                Console.WriteLine("Unsorted array:" + String.Join(" ", array.Select(x => x.ToString())));
    
                // array.Sort(); // probably not allowed
                for (int i = 0; i < array.Count() - 1; ++i)
                {
                    for (int j = 0; j < array.Count() - 1; ++j)
                    {
                        if (array[j] > array[j + 1]) Swap(array, j, j + 1);
                    }
                }
    
                Console.WriteLine("Sorted array:" + String.Join(" ", array.Select(x => x.ToString())));
            }
        }
    }

    using System;
    using System.Collections.Generic;
    static class Program
    {
        static void Main()
        {
    
            LinkedList<int> data = new LinkedList<int>();
            Random rand = new Random(12345);
            for (int i = 0; i < 20; i++)
            {
                data.InsertSortedValue(rand.Next(300));
            }
            foreach (int i in data) Console.WriteLine(i);
        }
    }
    static class LinkedListExtensions {
        public static void InsertSortedValue<T>(this LinkedList<T> list, T value)
        {
    
            LinkedListNode<T> node = list.First, next;
            if (node == null)
            {
                list.AddFirst(value);
            }
            else { 
                var comparer = Comparer<T>.Default;
                while ((next = node.Next) != null &&
                        comparer.Compare(next.Value, value) < 0)
                    node = next;
                list.AddAfter(node, value);
            }
        }
    }

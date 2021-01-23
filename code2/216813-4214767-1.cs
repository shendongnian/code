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
        public static void InsertSortedValue(this LinkedList<int> list, int value)
        {
            LinkedListNode<int> node = list.First, next;
            if (node == null || node.Value > value)
            {
                list.AddFirst(value);
            }
            else
            { 
                while ((next = node.Next) != null && next.Value < value)
                    node = next;
                list.AddAfter(node, value);
            }
        }
    }

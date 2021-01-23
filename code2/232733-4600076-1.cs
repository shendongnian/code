    using System;
    
    class Program
    {
        static void Main()
        {
            // Create an ArraySegment from this array.
            int[] array = { 10, 20, 30 };
            ArraySegment<int> segment = new ArraySegment<int>(array, 1, 2);
    
            // Write the array.
            Console.WriteLine("-- Array --");
            int[] original = segment.Array;
            foreach (int value in original)
            {
                Console.WriteLine(value);
            }
    
            // Write the offset.
            Console.WriteLine("-- Offset --");
            Console.WriteLine(segment.Offset);
    
            // Write the count.
            Console.WriteLine("-- Count --");
            Console.WriteLine(segment.Count);
    
            // Write the elements in the range specified in the ArraySegment.
            Console.WriteLine("-- Range --");
            for (int i = segment.Offset; i <= segment.Count; i++)
            {
                Console.WriteLine(segment.Array[i]);
            }
        }
    }

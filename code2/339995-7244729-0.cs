    using System;
    using System.Collections.Generic;
    
    public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        // You could make this a per-instance field with a constructor parameter
        private static readonly EqualityComparer<T> elementComparer
            = EqualityComparer<T>.Default;
        
        public bool Equals(T[] first, T[] second)
        {
            if (first == second)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            if (first.Length != second.Length)
            {
                return false;
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (!elementComparer.Equals(first[i], second[i]))
                {
                    return false;
                }
            }
            return true;
        }
        
        public int GetHashCode(T[] array)
        {
            unchecked
            {
                if (array == null)
                {
                    return 0;
                }
                int hash = 17;
                foreach (T element in array)
                {
                    hash = hash * 31 + elementComparer.GetHashCode(element);
                }
                return hash;
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            byte[] x = { 1, 2, 3 };
            byte[] y = { 1, 2, 3 };
            byte[] z = { 4, 5, 6 };
            
            var comparer = new ArrayEqualityComparer<byte>();
            
            Console.WriteLine(comparer.GetHashCode(x));
            Console.WriteLine(comparer.GetHashCode(y));
            Console.WriteLine(comparer.GetHashCode(z));
            Console.WriteLine(comparer.Equals(x, y));
            Console.WriteLine(comparer.Equals(x, z));
        }
    }

    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace MyILists
    {
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> intArrayList = new ArrayList().ToIList<int>();
            intArrayList.Add(1);
            intArrayList.Add(2);
            //intArrayList.Add("Sample Text"); // Will not compile
            foreach (int myInt in intArrayList)
            {
                Console.WriteLine(" Number : " + myInt.ToString());
            }
            Console.Read();
        }      
    }
    public static class MyExtensions
    {
        public static IList<T> ToIList<T>(this ArrayList arrayList)
        {
            IList<T> list = new List<T>(arrayList.Count);
            foreach (T instance in arrayList)
            {
                list.Add(instance);
            }
            return list;
        }
    }
    }

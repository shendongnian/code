    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
    public class Program
    {
        public static IComparable[] Sort(IComparable[] a)
    {
        Random r = new Random();
        a= a.OrderBy(x => r.Next()).ToArray();
            return a;
    }
    public static void Main(string[] args)
    {
        IComparable[] nums = {"1","3","7","4","2"};
        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }
        nums=Sort(nums);
        Console.WriteLine("After sorting:");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }
    }
    }
    }

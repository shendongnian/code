    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            var csvString = "G9999999990001800002777107050,G9999999990002777107HMNLAQKPRLLHRAQRWJ010,1,3,29,P,6.74,11.23,07,P,5.25,14.29,08,P,6.89,16.92,07,P,5,4,";
            var indexes = Enumerable.Range(1,100)
                .SelectMany(i => new [] {4*i, 4*i+1})
                .ToArray(); // 4,5,8,9,12,13 etc.
            var fields = csvString.Split(',');
            var selected = indexes
                .Where(i => i<fields.Length)
                .Select(i => fields[i]);
            Console.WriteLine(string.Join(" ", selected.ToArray()));
        }
    }

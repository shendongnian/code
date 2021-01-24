    using System;
    using System.Collections.Generic;
    namespace ConsoleApp2
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NumberToWordConverter nc = new NumberToWordConverter();
            Console.WriteLine(nc.ConvertNumberToWord(0));
            Console.WriteLine(nc.ConvertNumberToWord(5));
            Console.WriteLine(nc.ConvertNumberToWord(17));
            Console.WriteLine(nc.ConvertNumberToWord(37));
            Console.WriteLine(nc.ConvertNumberToWord(147));
            Console.WriteLine(nc.ConvertNumberToWord(252));
            Console.WriteLine(nc.ConvertNumberToWord(489));
            Console.WriteLine(nc.ConvertNumberToWord(900));
            Console.WriteLine(nc.ConvertNumberToWord(950));
            Console.WriteLine(nc.ConvertNumberToWord(999));
            Console.ReadLine();
        }
    }
    public class NumberToWordConverter
    {
        private Dictionary<long, string> numWordDict = new Dictionary<long, string>();
        public NumberToWordConverter()
        {
            numWordDict.Add(0, "zero");
            numWordDict.Add(1, "one");
            numWordDict.Add(2, "two");
            numWordDict.Add(3, "three");
            numWordDict.Add(4, "four");
            numWordDict.Add(5, "five");
            numWordDict.Add(6, "six");
            numWordDict.Add(7, "seven");
            numWordDict.Add(8, "eight");
            numWordDict.Add(9, "nine");
            numWordDict.Add(10, "ten");
            numWordDict.Add(11, "eleven");
            numWordDict.Add(12, "twelve");
            numWordDict.Add(13, "thirteen");
            numWordDict.Add(14, "fourteen");
            numWordDict.Add(15, "fifteen");
            numWordDict.Add(16, "sixteen");
            numWordDict.Add(17, "seventeen");
            numWordDict.Add(18, "eightteen");
            numWordDict.Add(19, "nineteen");
            numWordDict.Add(20, "twenty");
            numWordDict.Add(30, "thirty");
            numWordDict.Add(40, "forty");
            numWordDict.Add(50, "fifty");
            numWordDict.Add(60, "sixty");
            numWordDict.Add(70, "seventy");
            numWordDict.Add(80, "eighty");
            numWordDict.Add(90, "ninety");
            numWordDict.Add(100, "hundred");
        }
        /// <summary>
        /// Only goes up to 900 but you can modify this code to make it go up higher
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertNumberToWord(long number)
        {
            string nstring = string.Empty;
            if (number == 0)
            {
                return numWordDict[number];
            }
            if(number < 20)
            {
                return numWordDict[number];
            }
            long hundreds = number / 100;
            number -= hundreds * 100;
            long tens = number / 10;
            number -= tens * 10;
            long ones = number;
            if (hundreds > 0)
            {
                nstring = numWordDict[hundreds] + " " + numWordDict[100];
            }
            if (tens > 0)
            {
                if (!string.IsNullOrWhiteSpace(nstring))
                {
                    nstring += " and ";
                }
                nstring += numWordDict[tens * 10];
            }
            if (ones > 0)
            {
                if (!string.IsNullOrWhiteSpace(nstring))
                {
                    nstring += " ";
                }
                nstring += numWordDict[ones];
            }
            return nstring;
        }
    }

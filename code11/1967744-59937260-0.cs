    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication152
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = { "Week 02 [2020]", "Week 03 [2020]", "Week 36 [2019]", "Week 40 [2019]", "Week 47 [2019]", "Week 52 [2019]" };
                string[] output = input.Select(x => new Date(x)).OrderByDescending(x => x).Select(x => x.text).ToArray();
            }
        }
        public class Date : IComparable<Date>
        {
            public string text { get; set; }
            public int week { get; set; }
            public int year { get; set; }
            const string pattern = @"Week (?'week'\d+) \[(?'year'\d+)\]";
            public Date() { }
            public Date(string text)
            {
                this.text = text;
                Match match = Regex.Match(text,pattern);
                week = int.Parse(match.Groups["week"].Value);
                year = int.Parse(match.Groups["year"].Value);
            }
            public int CompareTo(Date other)
            {
                // If other is not a valid object reference, this instance is greater.
                if (this.year != other.year)
                {
                    return this.year.CompareTo(other.year);
                }
                else
                {
                    return this.week.CompareTo(other.week);
                }
            }
        }
     
    }

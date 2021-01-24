    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication131
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                    "0| Complete amount xxx€ 1| Shopping 25€ (calculated)",
                    "1.1| Aldi 20€ (inserted)",
                    "1.2| Lidl 5€ (inserted)",
                    "1.2.1| Milka 3€ (inserted)",
                    "1.2.2| Bath 2€ (calculated)",
                    "1.2.2.1| Toothbrush 1€ (inserted)",
                    "1.2.2.2| Soap 1€ (inserted) 2| Car 100€ (calculated)",
                    "2.1| Fuel 80€ (inserted)",
                    "2.2| washing 20€ (inserted) 3| Dinner"
                                 };
                SortParagraph sorter = new SortParagraph();
                List<SortParagraph> sortParagraphs = sorter.ParsePararaph(inputs);
                List<SortParagraph> sortedParagraphs = sortParagraphs.OrderBy(x => x).ToList();
                foreach (SortParagraph sortParagraph in sortParagraphs)
                {
                    Console.WriteLine("Para : '{0}', Titles = '{1}'", string.Join(".", sortParagraph.subParagraphs), string.Join(",", sortParagraph.titles));
                }
                Console.ReadLine();
            }
        }
        public class SortParagraph : IComparable<SortParagraph>
        {
            public int[] subParagraphs { get; set; }
            public string[] titles { get; set; }
            public List<SortParagraph> ParsePararaph(string[] inputs)
            {
                List<SortParagraph> paragraphs = new List<SortParagraph>();
                foreach(string input in inputs)
                {
                    SortParagraph newParagraph = new SortParagraph();
                    string[] splitParagraph = input.Split(new char[] { '|' }).ToArray();
                    newParagraph.titles = splitParagraph.Skip(1).ToArray();
                    newParagraph.subParagraphs = splitParagraph.First().Split(new char[] { '.' }).Select(x => int.Parse(x)).ToArray();
                    paragraphs.Add(newParagraph);
                }
                return paragraphs;
            }
            public int CompareTo(SortParagraph other)
            {
                int minSize = Math.Min(this.subParagraphs.Length, other.subParagraphs.Length);
                for (int i = 0; i < minSize; i++)
                {
                    if (this.subParagraphs[i] != other.subParagraphs[i])
                    {
                        if (this.subParagraphs[1] < other.subParagraphs[i])
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                if (this.subParagraphs.Length == other.subParagraphs.Length)
                {
                    return 0;
                }
                else
                {
                    if (this.subParagraphs.Length < other.subParagraphs.Length)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
     
    }

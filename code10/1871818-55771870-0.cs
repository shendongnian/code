    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = { "1.7.1", "1.7.10", "1.7.2", "1.7.3", "1.7.4", "1.7.5", "1.7.6", "1.7.7", "1.7.8", "1.7.9" };
                string[] output = MySort.Sort(input);
            }
        }
        public class MySort : IComparable
        {
            private string[] splitvalues { get; set; }
            public string filename { get; set; }
            public MySort(string filename)
            {
                this.filename = filename;
                splitvalues = filename.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            public static string[] Sort(string[] input)
            {
                return input.Select(x => new MySort(x)).OrderBy(x => x).Select(x => x.filename).ToArray();
            }
            public int CompareTo(object other)
            {
                MySort otherMySort = (MySort)other;
                int min = Math.Min(this.splitvalues.Length, otherMySort.splitvalues.Length);
                for (int i = 0; i < min; i++)
                {
                    string a = this.splitvalues[i];
                    string b = otherMySort.splitvalues[i];
                    if (a != b)
                    {
                        int numberA = 0;
                        int numberB = 0;
                        if (int.TryParse(a, out numberA))
                        {
                            if (int.TryParse(b, out numberB))
                            {
                                int z = numberA.CompareTo(numberB);
                                //a & b are numbers
                                return numberA.CompareTo(numberB);
                            }
                            else
                            {
                                //a number b string
                                return -1;
                            }
                        }
                        else
                        {
                            if (int.TryParse(b, out numberB))
                            {
                                //a string b number
                                return 1;
                            }
                            else
                            {
                                // a string b string
                                return a.CompareTo(b);
                            }
                        }
                    }
                }
                return splitvalues.Length.CompareTo(otherMySort.splitvalues.Length);
            }
        }
    }

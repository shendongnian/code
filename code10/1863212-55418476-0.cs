    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> input = new List<string>() { "1 Light", "1 Paper", "Bathroom 1", "Bathroom 2", "Bathroom 10", "Bedroom 1", "Bedroom 2", "Bedroom 10" };
                List<string> results = input.Select(x => new { s = x, order = new Order(x) }).OrderBy(x => x.order).Select(x => x.s).ToList();
            }
        }
        public class Order : IComparable<Order>
        {
            List<string> split { get; set; }
            public Order(string line)
            {
                split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            public int CompareTo(Order other)
            {
                
                int min = Math.Min(split.Count, other.split.Count);
                int thisNumber = 0;
                int otherNumber = 0;
                for (int i = 0; i < min; i++)
                {
                    if (split[i] != other.split[i])
                    {
                        if ((int.TryParse(split[i], out thisNumber)))
                        {
                            if ((int.TryParse(other.split[i], out otherNumber)))
                            {
                                return thisNumber.CompareTo(otherNumber); //both numbers
                            }
                            else
                            {
                                return -1; // this is number other is string : this comes first
                            }
                        }
                        else
                        {
                            if ((int.TryParse(other.split[i], out otherNumber)))
                            {
                                return 1; //other is number this is string : other comes first
                            }
                            else
                            {
                                return split[i].CompareTo(other.split[i]);
                            }
                        }
                    }
                }
                return split.Count.CompareTo(other.split.Count);
                
            }
        }
    }

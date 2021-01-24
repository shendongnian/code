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
                List<Fruit> fruits = new List<Fruit>() {
                    new Fruit() { fruit =  "Apple", quantity = 1, day = "monday"},
                    new Fruit() { fruit =  "Banana", quantity = 5, day = "monday"},
                    new Fruit() { fruit =  "Pear", quantity = 4, day = "tuesday"},
                    new Fruit() { fruit =  "Apple", quantity = 2, day = "tuesday"},
                    new Fruit() { fruit =  "Banana", quantity = 7, day = "tuesday"},
                    new Fruit() { fruit =  "Orange", quantity = 6, day = "wednesday"},
                    new Fruit() { fruit =  "Apple", quantity = 9, day = "thursday"},
                    new Fruit() { fruit =  "Banana", quantity = 2, day = "friday"}
                };
                List<Fruit> results = fruits.OrderBy(x => x).ToList();
                Dictionary<string, List<Fruit>> dict = results.GroupBy(x => x.fruit, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class Fruit : IComparable<Fruit>
        {
            public string fruit { get; set; }
            public int quantity { get; set; }
            dayofweek date { get; set; }
            public string day {
                get { return date.ToString();}
                set { date = (dayofweek)Enum.Parse(typeof(dayofweek), value);}
            }
            enum dayofweek
            {
                sunday = 0,
                monday = 1,
                tuesday = 2,
                wednesday = 3,
                thursday = 4,
                friday = 5,
                saturday = 6
            }
            public int CompareTo(Fruit other)
            {
                if (this.fruit != other.fruit)
                {
                    return this.fruit.CompareTo(other.fruit);
                }
                else
                {
                    if (this.date != other.date)
                    {
                        return this.date.CompareTo(other.date);
                    }
                    else
                    {
                        return this.quantity.CompareTo(other.quantity);
                    }
                }
            }
        }
    }

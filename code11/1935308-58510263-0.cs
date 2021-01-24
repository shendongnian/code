    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication137
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                Fruit fruit = new Fruit(FILENAME);
                Fruit.PrintFruits();
                Console.ReadLine();
            }
     
        }
        public class Fruit
        {
            public static List<Fruit> fruits { get; set; }
            public DateTime day { get; set; }
            public string name { get; set; }
            public string kind { get; set; }
            public decimal price { get; set; }
            public Fruit() { }
            public Fruit(string filename)
            {
                int count = 0;
                StreamReader reader = new StreamReader(filename);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (++count > 1)
                    {
                        string[] splitLine = line.Split(new char[] { ',' }).ToArray();
                        Fruit newFruit = new Fruit();
                        if (fruits == null) fruits = new List<Fruit>();
                        fruits.Add(newFruit);
                        newFruit.day = DateTime.Parse(splitLine[0]);
                        newFruit.name = splitLine[1];
                        newFruit.kind = splitLine[2];
                        newFruit.price  = decimal.Parse(splitLine[3]);
                    }
                }
                reader.Close();
            }
            public static void PrintFruits()
            {
                var groups = fruits.OrderBy(x => x.day)
                    .GroupBy(x => new { name = x.name, kind = x.kind })
                    .ToList();
                foreach (var group in groups)
                {
                    for (int i = 0; i < group.Count() - 1; i++)
                    {
                        Console.WriteLine("Old Date : '{0}', New Date : '{1}', Name : '{2}', Kind : '{3}', Old Price '{4}', New Price '{5}', Delta Price '{6}'",
                            group.ToList()[i].day.ToString("yyyy-MM-dd"),
                            group.ToList()[i + 1].day.ToString("yyyy-MM-dd"),
                            group.ToList()[i].name,
                            group.ToList()[i].kind,
                            group.ToList()[i].price.ToString(),
                            group.ToList()[i + 1].price.ToString(),
                            (group.ToList()[i + 1].price - group.ToList()[i].price).ToString()
                            );
                    }
                }
            }
        }
    }

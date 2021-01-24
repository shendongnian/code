    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Transportation
        {
            private string name; //name company
            private double cost; //unit price
            private double weight; // Shipping Weight
    
            public Transportation(string name, double cost, double weight)
            {
                Name = name;
                Cost = cost;
                Weight = weight;
            }
    
            public Transportation()
            {
                Name = "none";
                Cost = 0;
                Weight = 0;
            }
    
            public double Cost { get => cost; set => cost = value; }
            public string Name { get => name; set => name = value; }
            public double Weight { get => weight; set => weight = value; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Transportation[] company = GetTransportations();
                foreach (Transportation item in company)
                {
                    Console.WriteLine(item.Name + " => " + item.Cost + " => " + item.Weight);
                }
    
                Console.ReadKey();
            }
    
            public static Transportation[] GetTransportations()
            {
                string name = string.Empty; //name company
                double cost = 0; //unit price
                double weight = 0; // Shipping Weight
                Transportation[] transportations = new Transportation[] { };
    
                List<Transportation> transportationsList = new List<Transportation>();
    
                while (true)
                {
    
                    while (true)
                    {
                        Console.WriteLine("Insert the name of product: ");
                        name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name))
                        {
                            break;
                        }
                    }
    
                    while (true)
                    {
                        Console.WriteLine("Insert the cost of product: ");
                        string costString = Console.ReadLine();
                        if (double.TryParse(costString, out double c))
                        {
                            cost = c;
                            break;
                        }
                    }
    
                    while (true)
                    {
                        Console.WriteLine("Insert the weight of product: ");
                        string Sweight = Console.ReadLine();
                        if (double.TryParse(Sweight, out double w))
                        {
                            weight = w;
                            break;
                        }                    
                    }
    
                    transportationsList.Add(new Transportation(name, cost, weight));
    
                    Console.WriteLine("Continue to add products? Y/N: ");
                    string continueToAdd = Console.ReadLine();
    
                    if (continueToAdd.Substring(0, 1).ToUpper() == "N")
                    {                    
                        return transportationsList.ToArray();
                    }
    
                }
            }
    
        }
    }

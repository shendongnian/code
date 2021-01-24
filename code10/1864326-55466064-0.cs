    using System;
    using System.Collections.Generic;
    
    namespace BeachRentalsApp
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Welcome!");
    
                string name;
    
                while (true)
                {
                    Console.WriteLine("Enter your name:");
    
                    name = Console.ReadLine();
    
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                }
    
                Console.WriteLine("Enter your contract number or press Enter to generate one:");
    
                var contract = Console.ReadLine();
    
                if (string.IsNullOrWhiteSpace(contract))
                {
                    contract = $"{name[0]}{new Random().Next(1000, 10000)}";
                    Console.WriteLine($"Generated the following contract number: {contract}");
                }
    
                var minutes = GetNumber("For how long? (minutes, between 1 and 8 hours):", 60, 60 * 8);
    
                Console.WriteLine("We have the following items available:");
    
                var items = Rentals.Items;
    
                for (var i = 0; i < items.Length; i++)
                {
                    var item = items[i];
                    Console.WriteLine($"{i + 1}. {item.Name} ({item.Price:C})");
                }
    
                var dictionary = new Dictionary<Item, Rental>();
    
                while (true)
                {
                    var index = GetNumber("Choose an item or 0 to complete your order:", 0, items.Length);
                    if (index == 0)
                        break;
    
                    var quantity = GetNumber("Enter quantity:", 1, 9999);
    
                    var item = items[index - 1];
    
                    if (dictionary.ContainsKey(item))
                    {
                        dictionary[item].Duration = minutes;
                        dictionary[item].Quantity += quantity;
                    }
                    else
                    {
                        var rental = new Rental
                        {
                            Duration = minutes,
                            Quantity = quantity
                        };
                        dictionary.Add(item, rental);
                    }
                }
    
                Console.WriteLine();
    
                var total = 0.0m;
    
                Console.WriteLine("Here's your bill :)");
                Console.WriteLine();
    
                foreach (var pair in dictionary)
                {
                    var itemName = pair.Key.Name;
                    var itemQuantity = pair.Value.Quantity;
                    var itemDuration = pair.Value.Duration;
                    var itemPrice = pair.Key.Price;
                    var itemTotal = Math.Ceiling(itemDuration / 60.0m) * itemPrice * itemQuantity;
                    Console.WriteLine($"{itemName}:");
                    Console.WriteLine($"\tQuantity = {itemQuantity}");
                    Console.WriteLine($"\tDuration = {itemDuration}");
                    Console.WriteLine($"\tTotal = {itemTotal:C}");
                    Console.WriteLine();
                    total += itemTotal;
                }
    
                Console.WriteLine($"Grand total: {total:C}");
    
                Console.WriteLine();
                Console.WriteLine("We hope to see you again!");
    
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
    
                Console.ReadKey();
            }
    
            private static int GetNumber(string message, int min, int max)
            {
                if (message == null)
                    throw new ArgumentNullException(nameof(message));
    
                while (true)
                {
                    Console.WriteLine(message);
    
                    if (int.TryParse(Console.ReadLine(), out var number) && number >= min && number <= max)
                        return number;
                }
            }
        }
    
        public class Item
        {
            public Item(string name, decimal price)
            {
                if (price <= 0.0m)
                    throw new ArgumentOutOfRangeException(nameof(price));
    
                Name = name ?? throw new ArgumentNullException(nameof(name));
                Price = price;
            }
    
            public string Name { get; }
    
            public decimal Price { get; }
    
            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price:C}";
            }
    
            #region Equality members
    
            private bool Equals(Item other)
            {
                return string.Equals(Name, other.Name);
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != GetType())
                    return false;
    
                return Equals((Item) obj);
            }
    
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
    
            #endregion
        }
    
        public class Rental
        {
            public int Duration { get; set; }
    
            public int Quantity { get; set; }
        }
    
        public static class Rentals
        {
            public static Item[] Items { get; } =
            {
                new Item("Flotation Raft", 15.0m),
                new Item("Snorkel Gear", 25.0m)
            };
        }
    }

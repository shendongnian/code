    using System;
    using System.Collections.Generic;
    using System.Linq; 
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Ingredient> ingredients = new List<Ingredient>();
            Console.WriteLine("Please enter count of ingredient:");
            var countOfIngredient = int.Parse(Console.ReadLine());
            
            for (var i = 0; i < countOfIngredient; i++)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Please enter name of ingredient-{i}:");
                var name = Console.ReadLine();
                Console.WriteLine($"Please enter price of ingredient-{i}:");
                var price= double.Parse(Console.ReadLine());
                ingredients.Add(new Ingredient { Name = name, Price = price });
            }
            var cheapestIngredient = ingredients.OrderBy(i => i.Price).First();
            var mostExpensiveIngredient= ingredients.OrderByDescending(i => i.Price).First();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The most expensive ingredient is {mostExpensiveIngredient.Name} with price of {mostExpensiveIngredient.Price} $");
            Console.WriteLine($"The cheapest ingredient is {cheapestIngredient.Name} with price of {cheapestIngredient.Price} $");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
    class Ingredient
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

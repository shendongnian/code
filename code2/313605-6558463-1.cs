    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animalArray = { new Monkey(), new Cow() };
            foreach (Animal a in animalArray) {
                WhatDoIEat(a); // Prints "Bananas", then "Grass"
            }         
        }
        static void WhatDoIEat(Animal a)
        {
            Console.WriteLine(a.GetFood());
        }
    }
    

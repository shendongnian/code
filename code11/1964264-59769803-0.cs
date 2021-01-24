    class Program
    {
        static void Main(string[] args)
        {
            int broj;
            List<int> produktBrojeva = new List<int>();
            do
            {
                Console.WriteLine("Unesite broj: ");
                int.TryParse(Console.ReadLine(), out broj);
                if (broj <= 0)
                {
                    Console.WriteLine("Krivi unos.");
                }
                else
                {
                    produktBrojeva.Add(broj);
                }
            } while (broj != 0);
            Console.WriteLine();
            //Initialize with 1
            int produkt = 1;
            for (int i = 0; i < produktBrojeva.Count; i++)
            {
                //Calculate Product
                produkt *= produktBrojeva[i];
                Console.WriteLine(produktBrojeva[i]);
            }
            //Write Product to Console
            Console.WriteLine($"Product {produkt}");
        }
    }

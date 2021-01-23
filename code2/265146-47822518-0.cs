    static void Main(string[] args)
        {
            //Database producten
            Dictionary<string, double> producten = new Dictionary<string, double>();
            Console.WriteLine("Dit zijn de beschikbare producten");
            producten.Add("T-shirt", 45.35);
            Console.WriteLine("T-shirt");
            producten.Add("trui", 25.50);
            Console.WriteLine("trui");
            producten.Add("broek" , 90);
            Console.WriteLine("broek");
            //Einde database
            //Console.WriteLine(producten["trui"]);
            double tot = 0;
            bool boot = true;
            Dictionary<string, int> winkelmandje = new Dictionary<string, int>();
            while (boot)
            {
                Console.WriteLine("Wilt u een product toevoegen?, ja of nee?");
                string answer = Console.ReadLine();
                if (answer == "ja")
                {
                    Console.WriteLine("Geef de naam van het product?:");
                    string naam = Console.ReadLine();
                    Console.WriteLine("Hoeveel aantallen wenst u van dit product?:");
                    int inthvl = Convert.ToInt32(Console.ReadLine());
                    winkelmandje.Add(naam, inthvl);
                }
                if (answer == "nee")
                {
                    foreach(KeyValuePair<string, int> product in winkelmandje)
                    {
                        if (producten.ContainsKey(product.Key))
                        {
                            tot = tot + producten[product.Key] * product.Value;
                        }
                        else
                        {
                            Console.WriteLine("Dit product verkopen wij niet.");
                        }
                    }
                    boot = true;
                    Console.WriteLine("Gelieve " + tot + " euro te betalen.");
               
                }

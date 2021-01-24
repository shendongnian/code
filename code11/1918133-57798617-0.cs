     static void Main(string[] args)
        {
          List<string> Customers = new List<string>();
          Customers.Add("Faizan");
          Customers.Add("Ali");
          Customers.Add("Fazeel");
          Customers.Add("Salim");
          Customers.Add("Mueen");
          Customers.Add("Haleem");
          Customers.Add("Mazin");
            var abc = Customers.OrderBy(s => s.Length).ToList();
            foreach (var i in abc)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        
        }

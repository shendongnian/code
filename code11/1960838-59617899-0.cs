    class Program
    {
        static void Main(string[] args)
        {
            Artikl artikl = new Artikl {
              naziv ="Pivo", 
              kolicina  = 50
            };
            Console.WriteLine(artikl.naziv);
            Console.WriteLine(artikl.kolicina);
        }
    }

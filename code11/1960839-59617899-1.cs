    class Program
    {
        static void Main(string[] args)
        {
            Artikal artikal = new Artikal {
              naziv ="Pivo", 
              kolicina  = 50
            };
            Console.WriteLine(artikal.naziv);
            Console.WriteLine(artikal.kolicina);
        }
    }

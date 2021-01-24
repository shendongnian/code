    class Program
    {
        public  class ConexionBDD
        {
            public int hola { get; set; }
            public ConexionBDD()
            {
                this.hola = 2;
            }
        }
         static void Main(string[] args)
        {
            var tmp = new ConexionBDD();
            Console.WriteLine(tmp.hola);
            tmp.hola = 111;
            Console.WriteLine(tmp.hola);
            Console.ReadLine();
        }
    }

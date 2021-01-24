    class Program
    {
        public abstract class Koers
        {
            public string fonds { get; set; }
            public DateTime datum { get; set; }
            public Double koers { get; set; }
        }
        public class Historical : Koers
        {
        }
        private static void Display(List<Historical> cs)
        {
            Console.WriteLine();
            foreach (Historical item in cs)
            {
                Console.WriteLine("{0} {1} {2} ", item.fonds, item.datum.ToString(), item.koers);
            }
        }
        static void Main(string[] args)
        {
            Historical xkoers = new Historical();
            List<Historical> Historicals = new List<Historical>();
            Historicals.Add ( new Historical() { fonds = "EL1", datum = DateTime.Parse("2018-05-08"), koers = 310.1 } ) ;
            Historicals.Add ( new Historical() { fonds = "EL2", datum = DateTime.Parse("2018-06-08"), koers = 311.1 } ) ;
            xkoers.fonds = "AL3";
            xkoers.datum = DateTime.Parse("2018-05-08");
            xkoers.koers = 310.1;
            Historicals.Add(new Historical() { fonds=xkoers.fonds, datum=xkoers.datum, koers = xkoers.koers });
            xkoers.fonds = "AL4";
            xkoers.datum = DateTime.Parse("2018-06-08");
            xkoers.koers = 320.1;
            Historicals.Add(new Historical() { fonds = xkoers.fonds, datum = xkoers.datum, koers = xkoers.koers });
            xkoers.fonds = "Some other 5";
            xkoers.datum = DateTime.Parse("2019-06-08");
            xkoers.koers = 20.1;
            Historicals.Add(new Historical() { fonds = xkoers.fonds, datum = xkoers.datum, koers = xkoers.koers });
            Display(Historicals);
        }
    }

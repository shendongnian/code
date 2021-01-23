    class Program
    {
        public class Row
        {
            public int IdVersFirmFuente { get; set; }
            public int IdVersLib { get; set; }
            public int IdVersion { get; set; }
            public string CodVersion { get; set; }
        }
        static void Main()
        {
            var data = new[]
                           {
                               new Row { IdVersFirmFuente = 236, IdVersLib = 628, IdVersion = 628, CodVersion = "1.0.0.0" },
                               new Row { IdVersFirmFuente = 236, IdVersLib = 629, IdVersion = 629, CodVersion = "1.0.0.1" },
                               new Row { IdVersFirmFuente = 237, IdVersLib = 628, IdVersion = 628, CodVersion = "1.0.0.0" },
                               new Row { IdVersFirmFuente = 239, IdVersLib = 628, IdVersion = 628, CodVersion = "1.0.0.0" }
                           };
            var result = from u in data
                         group u by u.IdVersFirmFuente into g
                         select g.OrderByDescending(e => e.CodVersion).First();
            foreach (var row in result)
            {
                Console.WriteLine("{0,-5}{1,-5}{2,-5}{3,-10}", row.IdVersFirmFuente, row.IdVersLib, row.IdVersion, row.CodVersion);
            }
        }
    }

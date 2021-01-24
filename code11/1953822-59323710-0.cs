    interface IBook
    {
        string Name { get; set; }
    }
    interface IBookWithGenre : IBook
    {
        string Genre { get; set; }
    }
    public class FantasyBook : IBookWithGenre
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }
    public class HorrorBook : IBookWithGenre
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }
    public class SimpleBook : IBook
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FantasyBook LordOfTheRings = new FantasyBook();
            HorrorBook Frankenstein = new HorrorBook();
            SimpleBook abook = new SimpleBook();
            var books = new Dictionary<string, IBook>
            {
                { "LOTR", LordOfTheRings },
                { "Frankenstein", Frankenstein },
                { "Simple", abook },
            };
            books["LOTR"].Name = "Lord Of The Rings";
            if (books["LOTR"] is IBookWithGenre withGenre)
            {
                withGenre.Genre = "Fantasy";
            }
            Console.ReadLine();
        }
    }

    [BsonIgnoreExtraElements]
    public class TomatoViewer
    {
        public float rating;
        public int numReviews;
        public int meter;
    }
    [BsonIgnoreExtraElements]
    public class Tomato
    {
        public TomatoViewer viewer;
        public string production;
        public DateTime lastUpdated;
    }
    [BsonIgnoreExtraElements]
    public class Award
    {
        public int wins;
        public int nominations;
        public string text;
    }
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        public decimal rating;
        public int votes;
        public int id;
    }
    [BsonIgnoreExtraElements]
    public class Movie
    {
        public string plot;
        public IEnumerable<string> genres;
        public int runtime;
        public IEnumerable<string> cast;
        public dynamic title;
        public string fullplot;
        public IEnumerable<string> languages;
        public DateTime released;
        public IEnumerable<string> directors;
        public IEnumerable<string> writers;
        public Award awards;
        public string lastupdated;
        public int year;
        public Imdb imdb;
        public IEnumerable<string> countries;
        public string type;
        public Tomato tomatoes;
    }
    static void Main(string[] args)
    {
        var client =
            new MongoClient(
                "mongodb+srv://...");
        var database = client.GetDatabase("sample_mflix");
        var movies = database.GetCollection<Movie>("movies");
        var titles = movies.AsQueryable().Select(x => x.title).ToList();
        foreach (var numTitle in titles.OfType<int>())
        {
            Console.Write(numTitle);
        }
    }

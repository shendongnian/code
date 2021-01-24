    public class Dvd : IEquatable<Dvd>
    {
        public Dvd(string title, int releaseyear, string director, float rating)
        {
            Id = Interlocked.Increment(ref globalId);
            Title = title;
            ReleaseYear = releaseyear;
            Director = director;
            Rating = rating;
        }
        public static int globalId;
        public int Id { get; private set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public float Rating { get; set; }
        public bool Equals(Dvd other)
        {
            return other != null &&
                   Title == other.Title &&
                   ReleaseYear == other.ReleaseYear &&
                   Director == other.Director;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Dvd);
        }
        public override int GetHashCode()
        {
            return ((Title?.GetHashCode() ?? 17) * 17 +
                    ReleaseYear.GetHashCode()) * 17 +
                   (Director?.GetHashCode() ?? 17);
        }
    }

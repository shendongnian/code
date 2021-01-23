    public class Movie
    {
        public virtual string MovieTitle { get; set; }
        public virtual IList<Director> Directors { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<string> Directornames
        { get { return Directors.Select(dir => dir.Name); } }
    }
    public class Movie
    {
        public virtual int Id {get; protected set;}
        public virtual string Name {get; set;}
    }

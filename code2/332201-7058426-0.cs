    public class MyMovieMap : ClassMap<MyMovie>
    {
        public MyMovieMap()
        {
            Id(x => x.id);
            References(x => x.movie);
        }
    }
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Not.LazyLoad();
            Id<int>("m_id");
            Map(x => x.title);
            HasManyToMany(x => x.Directors)
                .Table("Directs")
                .LazyLoad();
        }
    }
    public class DirectorMap : ClassMap<Director>
    {
        public DirectorMap()
        {
            Not.LazyLoad();
            Id<int>("d_id");
            Map(x => x.name);
            HasManyToMany(x => x.DirectedMovies)
                .Table("Directs")
                .LazyLoad();
        }
    }

    class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Table("movie");
            Id(m => m.Id, "m_Id").GeneratedBy.Identity();
            Map(m => m.Title);
            Map(m => m.ReleaseDate);
            HasManyToMany(m => m.Directors)
                .Table("m_directs")
                .ParentKeyColumn("m_ID")
                .ChildKeyColumn("dirID")
                .AsBag()
                .Cascade.All();
        }
    }
    class DirectorMap : ClassMap<Director>
    {
        public DirectorMap()
        {
            Table("m_director");
            Id(d => d.Id, "dirID").GeneratedBy.Identity();
            Map(d => d.Name, "dirName");
        }
    }

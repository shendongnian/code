    public class Tag2Map : ClassMap<Tag2>
    {
        public Tag2Map()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Projects)
                .AsBag()
                .Cascade.None()
                .Table("ProjectsTags")
                .ParentKeyColumn("TagId")
                .ChildKeyColumn("ProjectId");
        }
    }
    public class Project2Map : ClassMap<Project2>
    {
        public Project2Map()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Tags)
                .AsBag()
                .Cascade.None()
                .Inverse()
                .Table("ProjectsTags")
                .ParentKeyColumn("ProjectId")
                .ChildKeyColumn("TagId");
        }
    }

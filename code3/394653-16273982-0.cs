    public class Make
    {
        public virtual int Id { get; set; }
    
        public virtual MakeId BusinessId { get; private set; }
    }
    
    public class MakeId
    {
        public virtual string Name { get; set; }
        public virtual string Year { get; set; }
    }
    
    public class MakeMap : ClassMap<Make>
    {
        public MakeMap()
        {
            Id(x => x.Id);
            Component("BusinessId", c => 
                c.Map(x => x.Name);
                c.Map(x => x.Year);
            });
    
            HasMany(x => x.Styles)
              .PropertyRef("BusinessId")
              .KeyColumns.Add("MakeName", "MakeYear")
              .Cascade.All();
            Table("Make");
        }
    }
    
    public class StyleMap : ClassMap<Style>
    {
        public StyleMap()
        {
            Table("Style");
    
            Id(x => x.Id);
            Map(x => x.Class);
    
            References(x => x.Make)
                .PropertyRef("BusinessId")
                .Columns.Add("MakeName", "MakeYear");
        }
    }

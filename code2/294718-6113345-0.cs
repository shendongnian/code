    public class Parent
    {
        public virtual int Id {get; set;}
        public virtual string Name { get; set; }
        public virtual string Family_id { get; set; }
        public virtual Children OldestChild {
         get {
              return Children.OrderBy(x=>x.BirthDate).FirstOrDefault();
         }}
        public virtual IList<Children> Children {get; set;}
    }
    
    public class ParentMap : ClassMap<Parent>{
        public ParentMap(){
            Id(x=>x.Id);
            Map(x=>x.Name);
            HasMany(x=>x.Children).PropertyRef("Family_id").Fetch.Join();
        }
    }

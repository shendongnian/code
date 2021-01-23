    public class SomeName
    {
        public string EntityType { get; set; }
        public bool IsTypeCDA { get { return EntityType == EntityType.CDA; } }
    }
...
    from x in DataContext.MyEntities
    select new SomeName
    {
        EntityType = x.EntityType
    }

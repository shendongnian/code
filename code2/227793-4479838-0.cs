    public class ClassOne
    {
        private IList<ClassTwo> _tags;
        public virtual Guid Guid { get; set; }
        public virtual String Title { get; set; }
        public virtual ClassTwo[] Tags
        {
            // possibly expose as method to hint that the array is re-built on every call
            get { return _tags.ToArray(); }
        }
    }
    public class ClassOneMap : ClassMap<ClassOneMap>
    {
        public ClassOneMap ()
        {
            Id(x => x.Guid).GeneratedBy.GuidComb();
            Map(x => x.Title);
            HasManyToMany(x => x.Tags).Access.CamelCaseField(Prefix.Underscore)
                .Cascade.SaveUpdate());
        }
    }

    class ActionsHolder
    {
        protected IList<TypeToEntity> innerList { get; set; }
        public IDictionary<NavigationType, IList<NavigationActionEntity>> NavigationActions
        { get { return new NavigationTypeMap(innerList); } }
    }
    class TypeToEntity
    {
        public virtual NavigationType Type { get; set; }
        public virtual NavigationActionEntity NavigationActionEntity { get; set; }
    }
    class MyClassMap : ClassMap<ActionsHolder>
    {
        public MyClassMap()
        {
            HasMany(Reveal.Member<ActionsHolder, IEnumerable<TypeToEntity>>("innerList"))
                .Table("NavTypeToNavActionEntity")
                .Component(c =>
                {
                    c.Map(x => x.Type);
                    c.References(x => x.NavigationActionEntity).Not.LazyLoad();
                })
                ;
        }
    }
    class NavigationTypeMap : IDictionary<NavigationType, IList<NavigationActionEntity>>
    {
        private IList<TypeToEntity> innerList;
        public NavigationTypeMap(IList<TypeToEntity> innerList)
        {
            // TODO: Complete member initialization
            this.innerList = innerList;
        }
        // TODO: implementation of IDictionary<>
    }

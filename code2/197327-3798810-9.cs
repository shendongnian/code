        public InfluenceConfiguration()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).IsIdentity();
            Property(o => o.Value);
 
            MapSingleType(o => new
            {
                o.Id,
                Trait = o.Trait.Id,
                o.Value,
                Template = o.Template.Id
            });
        } 

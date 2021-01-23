    class SiteMap : ClassMap<Site>
    {
        public SiteMap()
        {
            Join("MySchema.Options", join =>
            {
                join.KeyColumn("SiteId");
                join.Component(x => x.Options, c => c.Map(x => x.Prop1));
            });
        }
    }

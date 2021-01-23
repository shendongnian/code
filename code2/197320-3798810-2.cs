    public class InfluenceConfiguration : EntityConfiguration<Influence> 
    { 
        public InfluenceConfiguration() 
        { 
            HasKey(o => o.Id); 
            Property(o => o.Id).IsIdentity(); 
 
            HasRequired(o => o.Trait); 
            Property(o => o.Value); 
 
            MapSingleType(o => new { 
                o.Id, 
                Trait = o.Trait.Id, 
                o.Value 
            }); 
        } 
    } 

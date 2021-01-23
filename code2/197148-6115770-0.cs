    public class Map_Profilo : FluentNHibernate.Mapping.ClassMap
        {
            public Map_Profilo()
            {
                Table("TBA_Profilo");
    
                Id(x => x.Id).Column("id").GeneratedBy.Identity();
    
                Map(x => x.Matricola)
                    .Column("matricola");
    
                Map(x => x.Ruolo)
                    .Column("ruolo");
    
                HasMany(x => x.ListaSedi)
                    .AsBag()
                    .KeyColumns.Add("codice_sede")
                    .Not.LazyLoad()
                    .Cascade.SaveUpdate();
    
            }
        }
    public class Map_Sede : FluentNHibernate.Mapping.ClassMap
    {
        public Map_Sede()
        {
            Table("TBA_Sede");
            Id(x => x.CodiceSede).Column("codice_sede").GeneratedBy.Assigned();
            Map(x => x.DescrizioneSede)
                .Column("descrizione");
            References(prof => prof.Profilo)
                .Column("codice_sede")
                .Cascade.None()
                .Inverse();
        }
    }

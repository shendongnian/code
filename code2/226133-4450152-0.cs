    public class PartyMap : ClassMap<Party>
    {
        public PartyMap()
        {
            Table("Parties");
            Id(p => p.Id).GeneratedBy.Assigned();
            Map(p => p.Id);
        }
    }

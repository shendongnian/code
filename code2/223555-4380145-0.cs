    public class OrgMap : ClassMap<Org>
    {
        public OrgMap()
        {
            Table(@"Org_Updates");
            Id(x => x.ID);
            Map(x => x.IndividualName);
            Map(x => x.GroupName);
            Map(x => x.AddressLine1, "PhysicalLocationAddress");
            Map(x => x.AddressLine2, "PLAddr2");

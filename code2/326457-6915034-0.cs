    public class StatusMap : ClassMap<Status>
    {
        public StatusMap()
        {
            Id(x => x.Id, "ItemStatus").GeneratedBy.Assigned();
    
            DiscriminateSubClassesOnColumn<int>("ItemStatus", 0);
        }
    }

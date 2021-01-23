    public class ThingRepository : Repository<Thing>, IThingRepository
    {
        public int UpdateStatus(ThingStatus oldStatus, ThingStatus newStatus)
        {
            var query = Session.CreateQuery("UPDATE Thing SET Status = :newStatus WHERE Status = :oldStatus")
                .SetEnum("oldStatus", oldStatus)
                .SetEnum("newStatus", newStatus);
            return query.ExecuteUpdate();
        }
    }

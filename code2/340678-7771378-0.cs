    [EnableClientAccess()]
    public class SubscriptionService : DomainService
    {
        [Query(IsDefault = true)]
        public IQueryable<Subscription> GetSubscriptionList()
        {
            using(var dc = new SubscriptionDataContext())
                 return from x in dc.Subscription
                        where x.Status == STATUS.Active
                        select new Subscription { ID = x.ID, Name = x.Name };
            // make sure you don't call .ToList().AsQueryable() 
            // as you will basically load everything into memory, 
            // which you don't want to do if the client is going to be using 
            // any of the skip/take/where features of RIA Services.  
            // If you don't want to allow this, 
            // simply return an IEnumerable<Subscription>
        }
     }

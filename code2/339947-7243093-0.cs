    public class MyContext : ObjectContext
    {
        private ObjectSet<MyEntity> myEntities;
        public Expression<Func<MyEntity, bool>> GlobalMyEntityFilter { get; set; }
        public IQueryable<MyEntit> MyEntities
        {
            get
            {
                if (GlobalMyEntityFilter != null)
                {
                    return myEntities.Where(GlobalMyEntityFilter);
                }
                return myEntities;
            }
        }  
    }

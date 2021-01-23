    public class MyEntitiesRepository
    {
        private MyDbContext context;
        public MyEntitiesRepository() : this(new MyDbContext())
        { }
        public MyEntitiesRepository(MyDbContext context)
        {
            this.context = context;
        }
    }

    public class OrderRepository
    {
        private readonly DataContext dataContext;
        public void Save(Order entity)
        {
            entity.OrderDate = System.DateTime.Now;
            dataContext.Orders.Add(entity);
            dataContext.SaveChanges();
        }
        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }

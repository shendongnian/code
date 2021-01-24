    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(Entity.Expressions<Order>.Id);
            Map(x => x.EmployeeNumber)
                .Unique()
                .CustomType<EmployeeNumberUserType>();
        }
    }

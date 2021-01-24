    public class OrderDtoListMapper : ITypeConverter<OrderDtoList, List<Order>>
    {
        public List<Order> Convert(OrderDtoList source, List<Order> destination, ResolutionContext context)
        {
            return context.Mapper.Map<List<Order>>(source.Orders);
        }
    }

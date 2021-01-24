    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<OrderDtoList, List<Order>>().ConvertUsing<CustomConverter>();
        }
    }
    public class CustomConverter : ITypeConverter<OrderDtoList, List<Order>>
    {
        public List<Order> Convert(OrderDtoList source, List<Order> destination, ResolutionContext context)
        {
            return context.Mapper.Map<List<Order>>(source.Orders);
        }
    }

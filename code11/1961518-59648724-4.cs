    // Use lambda method
    CreateMap<OrderDtoList, List<Order>>()
        .ConvertUsing((source, _, context) => context.Mapper.Map<List<Order>>(source.Orders));
    // Use static method
    CreateMap<OrderDtoList, List<Order>>().ConvertUsing(ListConverter);
    private static List<Order> ListConverter(OrderDtoList source, List<Order> destination, ResolutionContext context)
    {
        return context.Mapper.Map<List<Order>>(source.Orders);
    }

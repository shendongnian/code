    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<OrderDtoList, List<Order>>().ConvertUsing<OrderDtoListMapper>();
        }
    }

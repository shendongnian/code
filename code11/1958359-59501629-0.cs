    var configuration = new MapperConfiguration(cfg =>
        cfg.CreateMap<OrderLine, OrderLineDTO>()
        .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name)));
    
    public List<OrderLineDTO> GetLinesForOrder(int orderId)
    {
      using (var context = new orderEntities())
      {
        return context.OrderLines.Where(ol => ol.OrderId == orderId)
                 .ProjectTo<OrderLineDTO>().ToList();
      }
    }

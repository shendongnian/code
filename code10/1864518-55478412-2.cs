public static void AddSessionTransformationMappings(IMapperConfiguration cfg)
{
    cfg.AllowNullCollections = true;
    cfg.CreateMap<IEnumerable<Info>, customerInfoList>()
        .ForMember(x => x.customerInfo, x => x.MapFrom(y => y));
    cfg.CreateMap<Info, customerInfo>()
        .ForMember(x => x.Item, x => x.ResolveUsing(y => CustomerInfoLevel(y)));
    cfg.CreateMap<Info, customerInfoBasic>()
        .ForMember(x => x.Name, x => x.MapFrom(y => y.name));
    cfg.CreateMap<Info, customerInfoSimple>()
        .ForMember(x => x.Name, x => x.MapFrom(y => y.name))
        .ForMember(x => x.Id, x => x.MapFrom(y => y.id));
    cfg.CreateMap<Info, customerInfoEnhanced>()
        .ForMember(x => x.Name, x => x.MapFrom(y => y.name))
        .ForMember(x => x.Id, x => x.MapFrom(y => y.id))
        .ForMember(x => x.Age, x => x.MapFrom(y => y.age));
}
private static Object CustomerInfoLevel(Info info)
{
    if (info.age != null)
    {
        return Mapper.Map<customerInfoEnhanced>(info);
    }
    if (info.id != null)
    {
        return Mapper.Map<customerInfoSimple>(info);
    }
    else
    {
        return Mapper.Map<customerInfoBasic>(info);
    }
}

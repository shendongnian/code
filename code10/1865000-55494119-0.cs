C#
var mapper = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<NestedObject, OutputNestedObject>();
    cfg.CreateMap<Input, Output>()
        .ForMember(x => x.OutputNestedObjects, src => src.MapFrom(x=> x.NestedObjects ))
        .AfterMap((src, dest) =>
        {
            foreach (OutputNestedObject nested in dest.OutputNestedObjects)
            {
                nested.InputID = src.ID;
            }
        })
        ;
}).CreateMapper();

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Root, Flattened>()
                .AfterMap((src, dest, context) => context.Mapper.Map(src.TheNestedClass, dest));
            CreateMap<Nested, Flattened>();
        }
    }

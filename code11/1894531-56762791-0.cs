    public static class mapConfig
    {
        public static ContainerBuilder RegisterObjectMappers(this ContainerBuilder builder)
        {
            builder.Register(c => GetV1MapperConfiguration().CreateMapper())
                .As<IMapper>().SingleInstance();
            return builder;
        }
        private static MapperConfiguration GetMapConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                // some mappings here
                cfg.CreateMap<C, D>().ReverseMap();
                cfg.CreateMap<A, B>().ConvertUsing<AToBConverter>();
            });
        }
    }
    public class AToBConverter : ITypeConverter<A, B>
    {
        public B Convert(A source, B destination, ResolutionContext context)
        {
            var b = new B
            {
                // internal values here aside from the repeated field(s)
            };
            // Need to use the Add method to add values rather than assign it with an '=' sign
            foreach (var someValue in source.someList)
            {
                b.someList.Add(context.Mapper.Map<D>(someValue));
            }
            return b;
        }
    }

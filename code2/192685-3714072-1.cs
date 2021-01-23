    using System;
    using AutoMapper;
    
    namespace TestAutoMapperComplex
    {
        public class Dto
        {
            public string Property { get; set; }
            public string SubProperty { get; set; }
        }
    
        public class Entity
        {
            public string Property { get; set; }
            public SubEntity Sub { get; set; }
        }
    
        public class SubEntity
        {
            public string SubProperty { get; set; }
        }
    
        static class MapperConfig
        {
            public static void Initialize()
            {
                Mapper.CreateMap<Dto, Entity>()
                    .ForMember(entity => entity.Sub, memberOptions =>
                        memberOptions.MapFrom(dto => dto));
                Mapper.CreateMap<Dto, SubEntity>();
            }
        }
    
        static class MapperConfig2
        {
            private class MyResolver : IValueResolver
            {
    
                public ResolutionResult Resolve(ResolutionResult source)
                {
                    var destinationSubEntity = ((Entity)source.Context.DestinationValue).Sub;
    
                    Mapper.Map((Dto)source.Value, destinationSubEntity);
    
                    return source.New(destinationSubEntity, typeof(SubEntity));
                }
            }
    
            public static void Initialize()
            {
                Mapper.CreateMap<Dto, Entity>()
                    .ForMember(entity => entity.Sub, memberOptions =>
                        memberOptions.ResolveUsing<MyResolver>());
                Mapper.CreateMap<Dto, SubEntity>();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MapperConfig.Initialize();
    
                var dto = new Dto {Property = "Hello", SubProperty = "World"};
                var subEntity = new SubEntity {SubProperty = "Universe"};
                var entity = new Entity {Property = "Good bye", Sub = subEntity};
    
                Mapper.Map(dto, entity);
    
                Console.WriteLine(string.Format("entity.Property == {0}, entity.Sub.SubProperty == {1}",
                    entity.Property, entity.Sub.SubProperty));
                Console.WriteLine(string.Format("entity.Sub == subEntity: {0}", 
                    entity.Sub == subEntity));
    
            }
        }
    }

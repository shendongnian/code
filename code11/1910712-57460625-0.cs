    using AutoMapper;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
    
                var mapper = mappingConfig.CreateMapper();
    
                var house = new House();
                var houseData = mapper.Map<HouseData>(house);
    
                var stockpile = new Stockpile();
                var stockpileData = mapper.Map<StockpileData>(stockpile);
            }
        }
    
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<House, HouseData>()
                    .ForMember(destination => destination.Position,
                               source => source.MapFrom(m => m.transform.Position));
    
                CreateMap<Stockpile, StockpileData>()
                    .ForMember(destination => destination.Position,
                               source => source.MapFrom(m => m.transform.Position));
            }
        }
    }

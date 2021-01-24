        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    
    namespace yournamespace.ViewModels.Mappings
    {
        public static class AutoMapperConfiguration
        {
            public static void Init()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<ReviewPostInputModel, Review>()
                    .ForMember(x => x.ReceiveThirdPartyUpdates, opt => opt.MapFrom(src => src.ReceiveThirdPartyUpdates ? (DateTime?)DateTime.UtcNow : null))
    				.ForMember(x => x.ReceiveUpdates, opt => opt.MapFrom(src => src.ReceiveUpdates ? (DateTime?)DateTime.UtcNow : null))
    				.ForMember(x => x.AverageScore, opt => opt.MapFrom(src => (decimal)Math.Round((src.Courtsey + src.Reliability + src.Tidiness + src.Workmanship) / 4, 2)));
                });
            }
        }
    }

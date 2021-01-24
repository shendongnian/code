    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {     
            CreateMap<ReviewPostInputModel, Review>()
                .ForMember(x => x.ReceiveThirdPartyUpdates, opt => opt.ResolveUsing(src => src.ReceiveThirdPartyUpdates ? (DateTime?)DateTime.UtcNow : null))
                .ForMember(x => x.ReceiveUpdates, opt => opt.ResolveUsing(src => src.ReceiveUpdates ? (DateTime?)DateTime.UtcNow : null))
                .ForMember(x => x.AverageScore, opt => opt.ResolveUsing(src => (decimal)Math.Round((src.Courtsey + src.Reliability + src.Tidiness + src.Workmanship) / 4, 2)));
            // ...
        }
    }

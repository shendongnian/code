 public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Entities.Member, Model.Member>(MemberList.Destination)
                .ForMember(d => d.Team, opt => opt.MapFrom(src => src.Team.Name));
        }
    }
In this example i assumed a property "Name" in your Team object.
And in your startup class you should register your profile in your AutoMapper configuration.

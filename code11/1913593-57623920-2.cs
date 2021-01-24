    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserForUpdateDto, User>()
                .ForMember(des=>des.StatusMessage,opt=>opt.MapFrom(src=>src.Status))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(des=>des.Referals,opt=>opt.MapFrom(src=>src.Referals))
                .ForMember(des => des.UserGroups, opt => opt.MapFrom(src => src.Groups))
                .AfterMap((src,des)=> {
                    foreach (var group in des.UserGroups)
                    {
                        group.UserId = src.UserId;
                    }
                });
            CreateMap<GroupViewModel, UserGroups>()
                .ForMember(des => des.Group, opt => opt.MapFrom(src => src));
            CreateMap<GroupViewModel, Group>();
            CreateMap<User, UserForUpdateDto>()
                .ForMember(des => des.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.StatusMessage))
                .ForMember(des => des.Referals, opt => opt.MapFrom(src => src.Referals))
                .ForMember(des => des.Groups, opt => opt.MapFrom(src => src.UserGroups));
            CreateMap<UserGroups, GroupViewModel>()
                .ForMember(des => des.GroupId, opt => opt.MapFrom(src => src.Group.GroupId))
                .ForMember(des => des.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));
            //CreateMap<Group, GroupViewModel>();
        }
    }

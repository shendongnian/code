    public MapperConfig()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserRole, RoleModel>()
                .ForMember(des=>des.RoleName,opt=>opt.MapFrom(src=>src.Role.RoleName));
            CreateMap<Role, RoleModel>();
            CreateMap<UserRole, UserModel>()
                .ForMember(des => des.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(des => des.Password, opt => opt.MapFrom(src => src.User.Password));
        }

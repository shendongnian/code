        private static void TestAutoMapper()
        {
            var mapperCfg = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                    .ForMember(dst => dst.UserGroups, opt => opt.Ignore())
                ;
                cfg.CreateMap<UserGroup, UserGroupDto>();
                cfg.CreateMap<Group, GroupDto>()
                    .ForMember(dst => dst.UserGroups, opt => opt.Ignore())
                ;
            });
            var mapper = mapperCfg.CreateMapper();
            var user = new User { Name = "User1" };
            var group = new Group { Name = "Group1" };
            var userGroups = new List<UserGroup> { new UserGroup { User = user, Group = group } };
            user.UserGroups = userGroups;
            group.UserGroups = userGroups;
            var users = new List<User> { user };
            var usersDto = users.Select(u =>
            {
                var dto = mapper.Map<User, UserDto>(u);
                dto.UserGroups = mapper.Map<IEnumerable<UserGroup>, IEnumerable<UserGroupDto>>(u.UserGroups).ToList();
                return dto;
            });
        }
 

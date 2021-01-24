        public static List<ParentDto> MapToDto(List<Parent> parents, List<Child> childs)
        {
            List<ParentDto> parentDtos = new List<ParentDto>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDto>().BeforeMap((s, d) =>
                {
                    d.ListChild = new List<ChildDto>();
                    foreach (var child in childs.Where(c => c.ParentID == s.ParentID))
                    {
                        d.ListChild.Add(new ChildDto { ChildCode = child.ChildCode, ChildID = child.ChildID });
                    }
                }).ForMember(dest => dest.ParentID, opt => opt.MapFrom(src => src.ParentID)).ForMember(dest => dest.ParentCode, opt => opt.MapFrom(src => src.ParentCode));
            });
            IMapper mapper = config.CreateMapper();
     
            foreach (var p in parents)
            {
                var source = p;
                var destination = mapper.Map<Parent, ParentDto>(source);
                parentDtos.Add(destination);
            }
            return parentDtos;
        }

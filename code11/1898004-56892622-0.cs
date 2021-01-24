    CreateMap<ProjectManager, GetProjectDto>()
                                .ForMember(dst => dst.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                                .ForMember(dst => dst.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName))
                                .ForMember(dst => dst.PlannedStartDate, opt => opt.MapFrom(src => src.Project.PlannedStartDate))
                                .ForMember(dst => dst.PlannedEndDate, opt => opt.MapFrom(src => src.Project.PlannedEndDate))
                                .ForMember(dst => dst.ActualStartDate, opt => opt.MapFrom(src => src.Project.ActualStartDate))
                                .ForMember(dst => dst.ActualEndDate, opt => opt.MapFrom(src => src.Project.ActualEndDate))
                                .ForMember(dst => dst.ProjectDescription, opt => opt.MapFrom(src => src.Project.ProjectDescription));
        
                    CreateMap<List<ProjectManager>, GetProjectManager>()
                                   .ForMember(dst => dst.ProjectManagerId,
                                                opt => opt.MapFrom(src =>
                                                                    src.FirstOrDefault().UserId))
                                   .ForMember(dst => dst.FirstName,
                                                opt => opt.MapFrom(src =>
                                                                    src.FirstOrDefault().User.FirstName))
                                   .ForMember(dst => dst.LastName,
                                                opt => opt.MapFrom(src =>
                                                                    src.FirstOrDefault().User.LastName))
                                   .ForMember(dst => dst.Email,
                                                opt => opt.MapFrom(src =>
                                                                    src.FirstOrDefault().User.Email))
                                    .ForMember(dst => dst.GetProjects,
                                                 opt => opt.MapFrom(src =>
                                                                    src.Select(x => new ProjectManager
                                                                    {
                                                                        Project = x.Project
                                                                    })));

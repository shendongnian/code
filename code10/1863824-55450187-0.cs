     Mapper.Initialize(conf => {
      conf.CreateMap<MCI, MCIDto>()
       .ForMember(dest => dest.UserDetails, m => m.MapFrom(src => new UserDetails {
          sessionId = src.sessionId,
          Userid = src.Userid,
          Username = src.Username,
          SocialServiceNo = src.SocialServiceNo
        }))
       .ForMember( dest => dest.EmpDetails, m => m.MapFrom(src => new EmployementDetails {
          Employee_No = src.Employee_No,
          Employer = src.Employer
       }))
     });

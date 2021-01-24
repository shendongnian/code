    var config = new MapperConfiguration(options =>
    {
        options.CreateMap<Contract.Dto.Result, List<Result>>(MemberList.Source).ConvertUsing<ResultConverter>();
        options.CreateMap<Contract.Dto.Result, Result>(MemberList.Source);
    });

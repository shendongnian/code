    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<SrcNested, DestFlat>(MemberList.Source);
        cfg.CreateMap<SrcRoot, DestFlat>(MemberList.Source)
            .ForSourceMember(s => s.Nested, x => x.Ignore())
            .AfterMap((s, d) => Mapper.Map(s.Nested, d));
    });
    Mapper.AssertConfigurationIsValid();
    var dest = Mapper.Map<SrcRoot, DestFlat>(src);

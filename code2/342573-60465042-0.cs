    public EmpClass
    {
       public string EmpName { get; set; }
       public int EmpId { get; set; }
    }
    this.CreateMap<IDictionary<string, object>, EmpClass>()
                    .ForMember(dest => dest.EmpName, src => src.MapFrom(x => x["EmpName"]))
                    .ForMember(dest => dest.EmpId, src => src.MapFrom(x => x["EmpId"]));

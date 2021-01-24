      CreateMap<ADTO, A>()
                .ForMember(dest => dest.AName, opt => opt.MapFrom(src => src.AName))
                .ForMember(dest => dest.ABs, opt => opt.MapFrom(src => src.Bs))
                .AfterMap((src, dest) =>{
                    foreach(var b in dest.ABs)
                    {
                        b.AId = src.Id;
                    }
                });
      CreateMap<B, AB>()
                .ForMember(dest=>dest.BId,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest=>dest.B,opt=>opt.MapFrom(src=>src));

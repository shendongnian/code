            CreateMap<Customer, CustomerDetails>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.CustomerInfo, opt => opt.MapFrom(s => s))
                .ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<Address, CustomerDetails>()
                .ForMember(d => d.CustomerAddress, opt => opt.MapFrom((s, d) => d.ID == s.CustomerID ? s : d.CustomerAddress))
                .ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<Address, IEnumerable<CustomerDetails>>()
                .ConvertUsing((a, d, ctx) =>
                {
                    CustomerDetails match = d.FirstOrDefault(c => c.ID == a.CustomerID);
                    if (match != null) 
                    {
                        ctx.Mapper.Map(match, a);
                    }
                    return d;
                });

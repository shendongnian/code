            CreateMap<Lead, LeadDto>()
                .ForMember(desc => desc.LeadCustomer, opt => opt.ResolveUsing(src =>
                {
                    return new LeadCustomer()
                    {
                        Id = src.LeadCustomerId,
                        FirstName = src.FirstName,
                        LastName = src.LastName,
                        EmailAddress = src.EmailAddress,
                        MobileNo = src.MobileNo
                    };
                }));

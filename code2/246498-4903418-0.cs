    public class CustomResolver
        : ValueResolver<SystemTransactionDTO, IHardwareSpecification>
    {
        protected override int ResolveCore(SystemTransactionDTO source)
        {
            return new CPUSpecification() { /* init from source fields */  };
        }
    }
    Mapper.CreateMap<SystemTransactionDTO, SystemTransaction>()
        .ForMember(dest => dest.Specification, opt => opt.ResolveUsing<CustomResolver>());

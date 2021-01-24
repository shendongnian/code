    public class SomeConverter : ITypeConverter<NameDTO, INameInterface>
    {
        public INameInterface Convert(NameDTO source, INameInterface destination, ResolutionContext context)
        {
            if (source.NameType == 0)
            {
                return context.Mapper.Map<FullName>(source);
            }
            if (source.FilterTypeId == 1)
            {
                return context.Mapper.Map<FirstNameOnly>(source);
            }
            return context.Mapper.Map<FirstNameOnly>(source);
        }
    }

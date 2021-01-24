    private class EnumerableToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IEnumerable<TITemSource>, RepeatedField<TITemDest>>
    {
        public RepeatedField<TITemDest> Convert(IEnumerable<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
        {
            destination = destination ?? new RepeatedField<TITemDest>();
            foreach (var item in source)
            {
                // obviously we haven't performed the mapping for the item yet
                // since AutoMapper didn't recognise the list conversion
                // so we need to map the item here and then add it to the new
                // collection
                destination.Add(context.Mapper.Map<TITemDest>(item));
            }
            return destination;
        }
    }

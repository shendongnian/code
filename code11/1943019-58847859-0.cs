    class TransposeConverter<TSource, TDestination> : ITypeConverter<TSource, IEnumerable<TDestination>> where TDestination : class, new()
    {
        public IEnumerable<TDestination> Convert(TSource source, IEnumerable<TDestination> destination, ResolutionContext context)
        {
            // Zip all the member collections from the source object together into a single collection then map to the destination based on the property names.
            return typeof(TSource).GetProperties()
                .Select(p => ((IEnumerable)p.GetValue(source)).Cast<object>().Select(item => (item, p.Name)))
                .Zip(s => context.Mapper.Map<TDestination>(s.ToDictionary(k => k.Name, e => e.item)));
        }
    }

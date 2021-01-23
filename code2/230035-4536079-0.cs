    // In this code IIdentifiable would be the same as IFoo in the original post.
    public class IdentifiableMapper : IObjectMapper
    {
        public bool IsMatch(ResolutionContext context)
        {
            var intType = typeof(int);
            var identifiableType = typeof(IIdentifiable);
            // Either the source is an int and the destination is an identifiable.
            // Or the source is an identifiable and the destination is an int.
            var result = (identifiableType.IsAssignableFrom(context.DestinationType) && intType == context.SourceType) || (identifiableType.IsAssignableFrom(context.SourceType) && intType == context.DestinationType);
            return result;
        }
        public object Map(ResolutionContext context, IMappingEngineRunner mapper)
        {
            // If source is int, create an identifiable for the destination.
            // Otherwise, get the Id of the identifiable.
            if (typeof(int) == context.SourceType)
            {
                var identifiable = (IIdentifiable)mapper.CreateObject(context);
                identifiable.Id = (int)context.SourceValue;
                return identifiable;
            }
            else
            {
                return ((IIdentifiable)context.SourceValue).Id;
            }
        }
    }

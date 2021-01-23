    public class SourceCollectionToDestCollection 
        : ITypeConverter<SourceCollection, DestCollection>
    {
        public DestCollection Convert(ResolutionContext context)
        {
            SourceCollection source = context.SourceValue as SourceCollection;
            
            DestCollection destination = context.DestinationValue as DestCollection 
                ?? new DestCollection();
    
            foreach (var sourceA in source.ACollection)
            {
                DestA dest = Mapper.Map<SourceA, DestA>(sourceA);
                destination.Collection.Add(dest);
            }
    
            foreach (var sourceB in source.BCollection)
            {
                DestB dest = Mapper.Map<SourceB, DestB>(sourceB);
                destination.Collection.Add(dest);
            }
    
            return destination;
        }
    }

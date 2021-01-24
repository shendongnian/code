    CreateMap<DtoMyClass, MyClass>().BeforeMap((dto, myclass, context) => context.Items["ThingCollectionId"] = dto.ThingCollectionId);
    CreateMap<DtoThing, Thing>().ConvertUsing<ThingTypeConverter>();
    public ThingTypeConverter: ITypeConverter<DtoThing, Thing> {
        private ThingCollections ThingCollections {get;}
        public MyClassMappingAction(ThingCollections thingCollections){
           ThingCollections = thingCollections;
        }
        public Thing Convert(DtoThing source, Thing destination, ResolutionContext context) {
            // Get the correct ThingCollection by ThingCollectionId
            var thingCollection = ThingCollections[(Guid)context.Items["ThingCollectionId"]];
            // Get the correct Thing from the ThingCollection by its Id
            return thingCollection.First(t => t.Id == source.Id);
        }
    }

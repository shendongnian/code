    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(mapperConfiguration =>
            {
                mapperConfiguration.AddProfile<DomainModelToYourDTOsMappingProfile>();
                mapperConfiguration.AddProfile<YourDTOsToDomainModelMappingProfile>();
                mapperConfiguration.AllowNullCollections = true;
                mapperConfiguration.ForAllMaps
                (
                    (mapType, mapperExpression) =>
                    {
                        mapperExpression.MaxDepth(1);
                    });
                });
            }
        }

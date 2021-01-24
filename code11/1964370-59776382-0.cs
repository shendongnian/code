public MappingProfile()
{
    CreateMap<SourceNamespace.ResponseValue, DtoNamespace.ResponseValue>();
    CreateMap<SourceNamespace.ResponseDocument, DtoNamespace.ResponseDocument>();
}

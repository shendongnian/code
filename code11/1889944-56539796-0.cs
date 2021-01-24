public class RequestProvider : IRequestProvider
{
    private readonly _mappingProvider;
    private int _someId;
    public RequestProvider(IDomainToRepoMappingRequestProvider mappingProvider)
    {
        _mappingProvider = mappingProvider
    }
    public int SomeId
    {
        get;
        set 
        {
            _someId = value;
            _mappingProvider.Map();
        }
    }
}

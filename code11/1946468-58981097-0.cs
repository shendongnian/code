public class HttpMagicService : IMagicService
{
    private readonly IMediator mediator;
    private readonly IServiceProvider services;
    public HttpMagicService(IMediator mediator, IServiceProvider services)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        this.services = services?? throw new ArgumentNullException(nameof(services));
    }
    public async Task AddAsync(Magic data, Metadata metadata)
    {
        using (var scope = Services.CreateScope())
        {
            var httpClient = scope.ServiceProvider.GetRequiredService<HttpClient>();
         ...
        }

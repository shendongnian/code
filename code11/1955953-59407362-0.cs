c#
public class Service2: PPlusAppServiceBase
{
    private readonly EditionAppService _editionAppService; // Add this
    private readonly Service1 _service1;                   // Add this
    private readonly IAbpSession _session;
    public Service2(
        EditionAppService editionAppService,               // Add this
        Service1 service1,                                 // Add this
        IAbpSession session)
    {
        _editionAppService = editionAppService;            // Add this
        _service1 = service1;                              // Add this
        _session = session;
    }
    public Entity getEntity()
    {
        Entity et = new Entity();
        // Service1 _service1 = new Service1(_session);    // Remove this
        // ...
        _service1.getEntity();
        // ...
        return et;
    }
    // ...
}
Related: https://stackoverflow.com/q/46653370/8601760

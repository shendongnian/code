public WebSocketManagerMiddleware(RequestDelegate next,
    IWebSocketConnectionDictionary webSocketDictionary,
    IServiceScopeFactory scopeFactory)
{
    _next = next;
    _webSocketManager = webSocketDictionary;
    _scopeFactory = scopeFactory;
}
You can then create a new scope and resolve the service from there whenever you need to access them.
using (var scope = _scopeFactory.CreateScope())
{
    var scopedOneService = scope.ServiceProvider.GetRequiredService<IScopedServiceOne>();
    var scopedTwoService = scope.ServiceProvider.GetRequiredService<IScopedServiceTwo>();
    // do something with scoped services
}
You should also read [this answer](https://stackoverflow.com/a/55710936) which is correct in this context but not in the context of the question Chris' answer was posted for, that's why it's been downvoted :)

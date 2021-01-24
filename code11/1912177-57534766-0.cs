public ProjectTaskNotifications(IUrlPrefixProvider provider)
{
    _urlPrefixProvider = urlPrefixProvider
}
private string BuildUrl(<Your args>)
{
    var prefix = _urlPrefixProvider.GetPrefix(<args>);
    ....
}
In startup.cs you can have
services.AddSingleton<IUrlPrefixProvider, MyUrlPrefixProvider>()
services.AddHostedService<ProjectTaskNotifications>();
and let dependency injection take care of the rest.

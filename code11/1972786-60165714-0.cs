razor
<Router AppAssembly="@typeof(Program).Assembly" @ref="router">
    <Found Context="routeData">
        <CascadingValue Value="@router">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
                ...
            </RouteView>
        </CascadingValue>
    </Found>
    <NotFound>
         ...
    </NotFound>
</Router>
@code {
    private Router router;
}
So now in any page of my app I can obtain the `Router` object using `CascadingParameterAttribute`. Next comes reflection (since a lot of things involved here are defined as `internal`):
csharp
public Type Find(Router router, string path) {
    var assm = typeof(Router).Assembly;
    var routes = typeof(Router).GetProperty("Routes", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(router);
    var type = assm.GetTypes().FirstOrDefault(t => t.Name == "RouteContext");
    var context = Activator.CreateInstance(type, new[] { path });
    routes.GetType().GetMethod("Route", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(routes, new[] { context });
    return type.GetProperty("Handler").GetValue(context) as Type;
}
And this function achieves exactly what I need.

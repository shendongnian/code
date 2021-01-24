cs
public class MockHttpApplication : HttpApplication
{
    public void RaiseBeginRequest()
    {
        FindEvent("EventBeginRequest").DynamicInvoke(this, EventArgs.Empty);
    }
    public void RaiseEndRequest()
    {
        FindEvent("EventEndRequest").DynamicInvoke(this, EventArgs.Empty);
    }
    private Delegate FindEvent(string name)
    {
        var key = typeof(HttpApplication)
                    .GetField(name, BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
        var events = typeof(HttpApplication)
                        .GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(this) as EventHandlerList;
        return events[key];
    }
}

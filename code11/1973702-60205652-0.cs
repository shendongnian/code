 c#
private static readonly object key = new object();
public static void MyExtensionMethod(this Container container)
{
            
    if (container.ContainerScope.GetItem(key) is null)
    {
        // do registrations here
        container.ContainerScope.SetItem(key, new object());
    }
}

<Grid x:Name="LayoutRoot">
    ...
</Grid>
Then in your code, you could find the probe user controls by name. Something like this:
var probe = LayoutRoot.GetChildByName<ProbeTestControl>($"probe{probe_number}");
Here is the extension method(s) that I use:
public static T GetChildByName<T>(this FrameworkElement element, string name)
    where T : FrameworkElement
{
    if (element == null) return null;
    return (T)element.FindName(name) ?? element.GetChildrenOfType<T>().FirstOrDefault(c => c.Name == name);
}
public static IEnumerable<T> GetChildrenOfType<T>(this DependencyObject element)
    where T : DependencyObject
{
    return element.GetChildrenRecursive().OfType<T>();
}
private static IEnumerable<DependencyObject> GetChildrenRecursive(this DependencyObject element)
{
    if (element == null)
    {
        throw new ArgumentNullException(nameof(element));
    }
    for (var i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
    {
        var child = VisualTreeHelper.GetChild(element, i);
        yield return child;
        foreach (var item in child.GetChildrenRecursive())
        {
            yield return item;
        }
    }
}
As long as all the probes exist in the same XAML tree, everything should work.
I hope this helps.

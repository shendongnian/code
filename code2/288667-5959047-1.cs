public class MyClass
{    
    protected readonly Dictionary&lt;Type, Component&gt; _components = new Dictionary&lt;Type, Component&gt;();
    public Component this [Type type]
    {
        get
        {
            Component component;
            _components.TryGetValue(type, out component);
            return component;
        }
    }
    public void AddComponent(Component component)
    {
        _components.Add(component.GetType(), component);
    }
}
public class MyClassTestHarness : MyClass
{
    public Dictionary&lt;Type, Component&gt; Components
    {
        get
        {
            return _components;
        }
    }
}

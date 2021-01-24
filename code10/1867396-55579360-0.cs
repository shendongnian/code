    public interface IMyInterface { }
    public class MyClass: IMyInterface { }
    //...
    var types = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => !t.IsInterface && t.GetInterfaces().Contains(typeof(IMyInterface)))
        .ToList();

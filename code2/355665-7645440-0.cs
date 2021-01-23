    // Your classes/interfaces.
    class Container
    {
        public static T Resolve<T>()
        {
            Console.WriteLine("Resolving {0}", typeof(T).FullName);
            return default(T);
        }
    }
    interface ICommandHandler<TModel>
    {
        void DoSomething();
    }
    // An implemented ICommandHandler.
    public class WackyCommandHandler : ICommandHandler<string>
    {
        public void DoSomething() { }
    }
    
    // Used to help the C# compiler identify types.
    public static class Identify
    {
        public static TypeIdentity<TType> TheType<TType>()
        {
            return null; // You don't actually need an instance.
        }
    }
    public sealed class TypeIdentity<TType>
    {
        private TypeIdentity() { }
    }
    // Your method
    static bool Handle<TCommandHandler, TModel>(TModel model, TypeIdentity<TCommandHandler> handler)
        where TCommandHandler : ICommandHandler<TModel>
    {
        var item = Container.Resolve<TCommandHandler>();
        return true;
    }
    // And the usage site:
    var a = "hello";
    Handle(a, Identify.TheType<WackyCommandHandler>());
    Console.ReadLine();

csharp
#region Plugin Framework
public delegate TTarget Command<out TTarget>(object obj);
/// <summary>
/// Abstract base class for plugins.
/// </summary>
public abstract class Plugin
{
}
#endregion
Next, here are two sample plugins. Note the `DynamicTarget` custom attributes, which I will describe in the next step.
csharp
#region Sample Plugin: ICustomerRepository
/// <summary>
/// Sample model class, representing a customer.
/// </summary>
public class Customer
{
    public Customer(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
/// <summary>
/// Sample target interface.
/// </summary>
public interface ICustomerRepository
{
    Customer AddCustomer(string name);
    Customer GetCustomer(string name);
}
/// <summary>
/// Sample plugin.
/// </summary>
[DynamicTarget(typeof(ICustomerRepository))]
public class CustomerRepositoryPlugin : Plugin, ICustomerRepository
{
    private readonly Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();
    public Customer AddCustomer(string name)
    {
        var customer = new Customer(name);
        _customers[name] = customer;
        return customer;
    }
    public Customer GetCustomer(string name)
    {
        return _customers[name];
    }
}
#endregion
#region Sample Plugin: IProductRepository
/// <summary>
/// Sample model class, representing a product.
/// </summary>
public class Product
{
    public Product(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
/// <summary>
/// Sample target interface.
/// </summary>
public interface IProductRepository
{
    Product AddProduct(string name);
    Product GetProduct(string name);
}
/// <summary>
/// Sample plugin.
/// </summary>
[DynamicTarget(typeof(IProductRepository))]
public class ProductRepositoryPlugin : Plugin, IProductRepository
{
    private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();
    public Product AddProduct(string name)
    {
        var product = new Product(name);
        _products[name] = product;
        return product;
    }
    public Product GetProduct(string name)
    {
        return _products[name];
    }
}
#endregion
Here's what your static `Repositories` class would look like with the two sample plugins:
csharp
#region Static Repositories Example Class from Question
public static class Repositories
{
    public static readonly Command<ICustomerRepository> CustomerRepositoryCommand = o => (ICustomerRepository) o;
    public static readonly Command<IProductRepository> ProductRepositoryCommand = o => (IProductRepository) o;
}
#endregion
To begin the actual answer to your question here's the custom attribute used to mark the plugins. This custom attribute has been used on the two example plugins shown above.
/// <summary>
/// Marks a plugin as the target of a <see cref="Command{TTarget}" />, specifying
/// the type to be registered with the <see cref="DynamicCommands" />.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class DynamicTargetAttribute : Attribute
{
    public DynamicTargetAttribute(Type type)
    {
        Type = type;
    }
    public Type Type { get; }
}
The custom attribute is parsed in the `RegisterDynamicTargets(Assembly)` of the following `DynamicRepository` class to identify the plugins and the types (e.g., `ICustomerRepository`) to be registered. The targets are registered with the `CommandRouter` shown below.
csharp
/// <summary>
/// A dynamic command repository.
/// </summary>
public static class DynamicCommands
{
    /// <summary>
    /// For all assemblies in the current domain, registers all targets marked with the
    /// <see cref="DynamicTargetAttribute" />.
    /// </summary>
    public static void RegisterDynamicTargets()
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            RegisterDynamicTargets(assembly);
        }
    }
    /// <summary>
    /// For the given <see cref="Assembly" />, registers all targets marked with the
    /// <see cref="DynamicTargetAttribute" />.
    /// </summary>
    /// <param name="assembly"></param>
    public static void RegisterDynamicTargets(Assembly assembly)
    {
        IEnumerable<Type> types = assembly
            .GetTypes()
            .Where(type => type.CustomAttributes
                .Any(ca => ca.AttributeType == typeof(DynamicTargetAttribute)));
        foreach (Type type in types)
        {
            // Note: This assumes that we simply instantiate an instance upon registration.
            // You might have a different convention with your plugins (e.g., they might be
            // singletons accessed via an Instance or Default property). Therefore, you
            // might have to change this.
            object target = Activator.CreateInstance(type);
            IEnumerable<CustomAttributeData> customAttributes = type.CustomAttributes
                .Where(ca => ca.AttributeType == typeof(DynamicTargetAttribute));
            foreach (CustomAttributeData customAttribute in customAttributes)
            {
                CustomAttributeTypedArgument argument = customAttribute.ConstructorArguments.First();
                CommandRouter.Default.RegisterTarget((Type) argument.Value, target);
            }
        }
    }
    /// <summary>
    /// Registers the given target.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    /// <param name="target">The target.</param>
    public static void RegisterTarget<TTarget>(TTarget target)
    {
        CommandRouter.Default.RegisterTarget(target);
    }
    /// <summary>
    /// Gets the <see cref="Command{TTarget}" /> for the given <typeparamref name="TTarget" />
    /// type.
    /// </summary>
    /// <typeparam name="TTarget">The target type.</typeparam>
    /// <returns>The <see cref="Command{TTarget}" />.</returns>
    public static Command<TTarget> Get<TTarget>()
    {
        return obj => (TTarget) obj;
    }
    /// <summary>
    /// Extension method used to help dispatch the command.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    /// <typeparam name="TResult">The type of the result of the function invoked on the target.</typeparam>
    /// <param name="_">The <see cref="Command{TTarget}" />.</param>
    /// <param name="func">The function invoked on the target.</param>
    /// <returns>The result of the function invoked on the target.</returns>
    public static TResult Execute<TTarget, TResult>(this Command<TTarget> _, Func<TTarget, TResult> func)
    {
        return CommandRouter.Default.Execute(func);
    }
}
Instead of dynamically creating properties, the above utility class offers a simple `Command<TTarget> Get<TTarget>()` method, with which you can create the `Command<TTarget>` instance, which is then used in the `Execute` extension method. The latter method finally delegates to the `CommandRouter` shown next.
csharp
/// <summary>
/// Command router used to dispatch commands to targets.
/// </summary>
public class CommandRouter
{
    public static readonly CommandRouter Default = new CommandRouter();
    private readonly Dictionary<Type, object> _commandTargets = new Dictionary<Type, object>();
    /// <summary>
    /// Registers a target.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target instance.</typeparam>
    /// <param name="target">The target instance.</param>
    public void RegisterTarget<TTarget>(TTarget target)
    {
        _commandTargets[typeof(TTarget)] = target;
    }
    /// <summary>
    /// Registers a target instance by <see cref="Type" />.
    /// </summary>
    /// <param name="type">The <see cref="Type" /> of the target.</param>
    /// <param name="target">The target instance.</param>
    public void RegisterTarget(Type type, object target)
    {
        _commandTargets[type] = target;
    }
    internal TResult Execute<TTarget, TResult>(Func<TTarget, TResult> func)
    {
        var result = default(TResult);
        if (_commandTargets.TryGetValue(typeof(TTarget), out object target))
        {
            result = func((TTarget)target);
        }
        return result;
    }
}
#endregion
Finally, here are a few unit tests showing how the above classes work.
csharp
#region Unit Tests
public class DynamicCommandTests
{
    [Fact]
    public void TestUsingStaticRepository_StaticDeclaration_Success()
    {
        ICustomerRepository customerRepository = new CustomerRepositoryPlugin();
        CommandRouter.Default.RegisterTarget(customerRepository);
        Command<ICustomerRepository> command = Repositories.CustomerRepositoryCommand;
        Customer expected = command.Execute(repo => repo.AddCustomer("Bob"));
        Customer actual = command.Execute(repo => repo.GetCustomer("Bob"));
        Assert.Equal(expected, actual);
        Assert.Equal("Bob", actual.Name);
    }
    [Fact]
    public void TestUsingDynamicRepository_ManualRegistration_Success()
    {
        ICustomerRepository customerRepository = new CustomerRepositoryPlugin();
        DynamicCommands.RegisterTarget(customerRepository);
        Command<ICustomerRepository> command = DynamicCommands.Get<ICustomerRepository>();
        Customer expected = command.Execute(repo => repo.AddCustomer("Bob"));
        Customer actual = command.Execute(repo => repo.GetCustomer("Bob"));
        Assert.Equal(expected, actual);
        Assert.Equal("Bob", actual.Name);
    }
    [Fact]
    public void TestUsingDynamicRepository_DynamicRegistration_Success()
    {
        // Register all plugins, i.e., CustomerRepositoryPlugin and ProductRepositoryPlugin
        // in this test case.
        DynamicCommands.RegisterDynamicTargets();
        // Invoke ICustomerRepository methods on CustomerRepositoryPlugin target.
        Command<ICustomerRepository> customerCommand = DynamicCommands.Get<ICustomerRepository>();
        Customer expectedBob = customerCommand.Execute(repo => repo.AddCustomer("Bob"));
        Customer actualBob = customerCommand.Execute(repo => repo.GetCustomer("Bob"));
        Assert.Equal(expectedBob, actualBob);
        Assert.Equal("Bob", actualBob.Name);
        // Invoke IProductRepository methods on ProductRepositoryPlugin target.
        Command<IProductRepository> productCommand = DynamicCommands.Get<IProductRepository>();
        Product expectedHammer = productCommand.Execute(repo => repo.AddProduct("Hammer"));
        Product actualHammer = productCommand.Execute(repo => repo.GetProduct("Hammer"));
        Assert.Equal(expectedHammer, actualHammer);
        Assert.Equal("Hammer", actualHammer.Name);
    }
}
#endregion
You can find the whole implementation [here][1].
  [1]: https://github.com/ThomasBarnekow/CodeSnippets/blob/master/CodeSnippets.Tests/DynamicCommandTests.cs

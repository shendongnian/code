public class ClientContext { }
public interface IEntityValidator<T> { }
public class Branch { }
public class BranchValidator : IEntityValidator<Branch>
{
    public BranchValidator(ClientContext clientContext)
    {
        Console.WriteLine("Creating a BranchValidator with context {0}", clientContext);
    }
}
public class Other { }
public class OtherValidator : IEntityValidator<Other> { }
public static class ValidatorLocator
{
    private static readonly Dictionary<Type, Type> ValidatorContainer
        = new Dictionary<Type, Type>();
    
    /// <summary>
    /// Use this method to register the validator class for an entity type.
    /// It should have a constructor with ClientContext parameter
    /// </summary>
    public static void RegisterValidator<TEntity,TEntityValidator>()
        where TEntityValidator : IEntityValidator<TEntity>
    {
        Console.WriteLine("=== RegisterValidator ===");
        Console.WriteLine("Registering {0} to validate {1}:", 
            typeof(TEntityValidator), typeof(TEntity));
        ValidatorContainer.Add(typeof(TEntity), typeof(TEntityValidator));
        Console.WriteLine("  Checking constructor with ClientContext parameter"); 
        var ctorParamTypes = new[] {typeof(ClientContext)};
        var validatorCtor = typeof(TEntityValidator).GetConstructor(ctorParamTypes);
        if (validatorCtor == null)
            Console.WriteLine("  Couldn't find the constructor!!");
        else
            Console.WriteLine("  Successfully registered!");
    }
    public static IEntityValidator<TEntity> GetValidator<TEntity>(ClientContext clientContext)
    {
        Console.WriteLine("=== GetValidator ===");
        Console.WriteLine("Getting validator for {0}", typeof(TEntity));
        var validatorType = ValidatorContainer[typeof(TEntity)];
        Console.WriteLine("  Looking for the constructor");
        var ctorParamTypes = new[] {typeof(ClientContext)};
        var validatorCtor = validatorType.GetConstructor(ctorParamTypes);
        Console.WriteLine("  Constructor found");
        var ctorParams = new[] {clientContext};
        Console.WriteLine("  Creating validator");
        var validator = validatorCtor.Invoke(ctorParams);
        Console.WriteLine("  Succesfully created");
        return (IEntityValidator<TEntity>)validator;
    }
}
To use it, you must register the validator class for each entity type, and then you can find the service constructor and invoke it. There are variations for this technique: for example you can register a singleton instance of each validator and reuse it, instead of looking for the constructor and invoking it in every use.
NOTE: *obvously the `Console.WriteLine`'s are there to see what's going on, but are not necessary on a real implementation*
Usage example:
class Program
{
    static void Main(string[] args)
    {
        ValidatorLocator.RegisterValidator<Branch,BranchValidator>();
        ValidatorLocator.RegisterValidator<Other,OtherValidator>();
        var clientContex = new ClientContext();
        ValidatorLocator.GetValidator<Branch>(clientContext);
        Console.WriteLine("Press a key to exit!!");
        Console.ReadKey();
    }
}

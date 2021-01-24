public interface IPersistence
{
    void ExecuteOperation(string prodecureName, Dictionary<string, object> parameters);
    T ExecuteSingle(string procedureName, Dictionary<string, object> parameters, Func<IDataReader, T> rowReader);
    List<T> ExecuteMultirow(string procedureName, Dictionary<string, object> parameters, 
Func<IDataReader, T> rowReader);
}
And then in repository I put it as dependency and from IoC container decide which implementation to use.
So in your code you'd have:
public class CustomerRepository
{
    private readonly IPersistence persistence;
    public CustomerRepository(IPersistence persistence)
    {
        this.persistence = persistence;
    }
    public virtual Customer LoadCustomer()
    {
        // preparation code
        return this.persistence.ExecuteSingle("some procedure", parameters, r => new Customer((int)r["Id"], (string)r["DisplayName"]));
    }
}

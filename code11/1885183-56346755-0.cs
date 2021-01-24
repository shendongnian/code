public class CustomerList : IEnumerable 
{
    ... // Your current code \\ ...
    public IEnumerator GetEnumerator()
    {
        return customers.GetEnumerator();
    }
}

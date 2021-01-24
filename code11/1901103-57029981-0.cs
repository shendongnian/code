c#
public interface ITest
{
    public string Id { get; set; }
}
public class MyObject : ITest {
{
    public string Id { get; set; }
    public string Value { get; set; }
}
public void Run()
{
    List<MyOBject> myObjects = new List<MyOBject>(); // With your objects
    myObjects = GetTestItems<MyOBject>(myObjects);
}
public IList<T> GetTestItems<T>(IList<T> items)
where T : ITest
{
    //run some logic with props of ITest
    return items;
}

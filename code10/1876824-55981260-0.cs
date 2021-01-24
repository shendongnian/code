csharp
// the type to test
public class TestData
{
    public string A { get; set; }
    public List<string> B { get; set; }
    public List<int> C { get; set; }
}
// an helper class used to generate checking functions
public static class ListTester
{
    public static Func<T, bool> MakeClassChecker<T>()
        where T : class
    {
        var checkFunctions = EnumerateListProperties<T>()
            .Select(MakePropertyChecker<T>)
            .ToList();
        return instance => checkFunctions.All(f => f(instance));
    }
    public static IEnumerable<PropertyInfo> EnumerateListProperties<T>()
    {
        return typeof(T).GetProperties(Instance | Public | NonPublic)
            .Where(prop => IsListClosedType(prop.PropertyType));
    }
    public static Func<T, bool> MakePropertyChecker<T>(PropertyInfo prop)
        where T : class
    {
        var propType = prop.PropertyType;
        var listItemType = propType.GenericTypeArguments[0];
        var listEmptyChecker = (Func<object, bool>) ListCheckerFactoryMethod
            .MakeGenericMethod(listItemType).Invoke(null, new object[0]);
        return instance => instance != null && listEmptyChecker(prop.GetValue(instance));
    }
    private static MethodInfo ListCheckerFactoryMethod
        = typeof(ListTester).GetMethod(nameof(ListCheckerFactory), Static | Public);
    public static Func<object, bool> ListCheckerFactory<T>()
    {
        return list => list == null || ((List<T>) list).Count == 0;
    }
    public static bool IsListClosedType(Type type)
    {
        return type != null &&
                type.IsConstructedGenericType &&
                type.GetGenericTypeDefinition() == typeof(List<>);
    }
}
[Test]
public void TestTemp()
{
    var props = ListTester.EnumerateListProperties<TestData>();
    CollectionAssert.AreEquivalent(props.Select(prop => prop.Name), new[] {"B", "C"});
    var allListsAreNullOrEmpty = ListTester.MakeClassChecker<TestData>();
    Assert.That(allListsAreNullOrEmpty(new TestData()), Is.True);
    Assert.That(allListsAreNullOrEmpty(new TestData() {B = new List<string>()}), Is.True);
    Assert.That(allListsAreNullOrEmpty(new TestData() {B = new List<string>() {"A"}}), Is.False);
}
Now, for the important bits: you search for properties of _closed_ generic types of `List<>`.
The selection of the properties is done in `IsListClosedType`.
Then, for each property, we make a checking function using `MakePropertyChecker`.
The job of `MakePropertyChecker` is to build via `MakeGenericMethod` a version of `ListCheckerFactory`
of the appropriate type.

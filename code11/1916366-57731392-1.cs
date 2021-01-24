C#
[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple =true)]
public class NoParallel : Attribute
{
    public NoParallel(string nonParallelGroupName)
    {
        SetName = nonParallelGroupName;
    }
    public string SetName { get; }
}
Then I went and added it to my test methods that will conflict.
C#
[NoParallel("Tax")]
public void TestPrice_5PercentTax();
[NoParallel("Tax")]
public void TestPrice_10PercentTax();
[NoParallel("Tax")]
public void TestPrice_NoTax();
// This test doesn't care
public void TestInventory_Add10Items();
// This test doesn't care
public void TestInventory_Remove10Items();
I gave my test class a static dictionary of mutexes keyed by their names.
C#
private static Dictionary<string, Mutex> exclusiveCategories = new Dictionary<string, Mutex>();
Finally, using a helper to grab all of the "NoParallel" strings the test method has...
C#
public static List<string> NonparallelSets(this TestContext context, ContextHandler testInstance)
{
    var result = new List<string>();
    var testName = context.TestName;
    var testClassType = testInstance.GetType();
    var testMethod = testClassType.GetMethod(testName);
    if (testMethod != null)
    {
        var nonParallelGroup = testMethod.GetCustomAttribute<NoParallel>(true);
        if (nonParallelGroup != null)
        {
            result = nonParallelGroups.Select(x => x.SetName).ToList();
        }
    }
    result.Sort();
    return result;
}
... I set up a TestInitialize and TestCleanup to make the tests with matching NoParallel strings execute in order.
C#
[TestInitialize]
public void PerformSetup()
{
    // Get all "NoParallel" strings on the test method currently being run
    var nonParallelSets = testContext.NonparallelSets(this);
    
    // A test can have multiple "NoParallel" attributes so do this for all of them
    foreach (var setName in nonParallelSets)
    {
        // If this NoParallel set doesn't have a mutex yet, make one
        Mutex mutex;
        if (exclusiveCategories.ContainsKey(setName))
        {
            mutex = exclusiveCategories[setName];
        }
        else
        {
            mutex = new System.Threading.Mutex();
            exclusiveCategories[setName] = mutex;
        }
        
        // Wait for the mutex before you can run the test
        mutex.WaitOne();
    }
}
[TestCleanup]
public void PerformTeardown()
{
    // Get the "NoParallel" strings on the test method again
    var nonParallelSets = testContext.NonparallelSets(this);
    
    // Release the mutex held for each one
    foreach (var setName in nonParallelSets)
    {
        var mutex = exclusiveCategories[setName];
        mutex.ReleaseMutex();
    }
}
We decided not to pursue this because it wasn't really worth the effort. Ultimately we decided to pull the tests that can't run together into their own test class, and mark them with `[DoNotParallelize]` as H.N suggested.

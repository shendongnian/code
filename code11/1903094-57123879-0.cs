//// This one throws System.ArgumentException 
//[TestCaseSource("GetDataString")]
//public void TestMethod(List<Config> configs)
//{
//    Console.WriteLine("Config " + configs);
//}
// This one is ok
[TestCaseSource("GetDataString")]
public void TestMethod(Config config)
{
    Console.WriteLine(config);
}
If you need to get `List<Config>` instances in your test, then your source must return some collection containing list items.

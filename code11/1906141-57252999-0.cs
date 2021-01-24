[TestClass]
public class MyTestClass
{
   private int originalValue; // adjust the type as needed
   [TestInitialize]
   public void PreTest()
   {
      // remember the value before the test
      originalValue = MyContainer.StaticValue; // or whatever it is called in your system
   }
   [TestCleanup]
   public void PostTest()
   {
      // check the current value against the remembered original one
     if (MyContainer.StaticValue != originalValue)
     {
        throw new InvalidOperationException($"Value was modified from {originalValue} to {MyContainer.StaticValue}!");
     }
   }
   [TestMethod]
   public void ExecuteTheTest()
   {
      // ...
   }
}
For other attributes, see a [cheatsheet](https://www.automatetheplanet.com/mstest-cheat-sheet/)

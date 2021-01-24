public class MyDataClass
{
    public static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData("3", "+", "3").Returns("6");
            yield return new TestCaseData("5", "+", "10").Returns("15");
        }
    }  
}
[Test]
[TestCaseSource(typeof(MyDataClass), "TestCases")]
public void Test(List<string> calculation, string result)
{
      var result = SolveCalculation(calculation);
      Assert.That(result, Is.EqualTo(result));
}
  [1]: https://github.com/nunit/docs/wiki/TestCaseData

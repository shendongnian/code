[JsonConverter(typeof(StringEnumConverter))]
public enum TestType
{
    FirstOption,
    SecondOption,
    ThirdOption
}
	
public const TestType Unlucky13 = (TestType)13;
	
public static void Main()
{
    var testCase = new[] { TestType.FirstOption, TestType.SecondOption };
    Console.WriteLine(JsonConvert.SerializeObject(testCase));
    testCase[0] = Unlucky13;
    Console.WriteLine(JsonConvert.SerializeObject(testCase));
}
The output is:
["FirstOption","SecondOption"]
[13,"SecondOption"]
  [1]: https://stackoverflow.com/questions/432937/net-why-arent-enums-range-value-checked

public static class Solutions
{
    public static string UsingIndexOf(string input)
    {
        const string tag = "VersionName=";
        var tagStart = input.IndexOf(tag);
        if (tagStart == -1)
        {
            return null;
        }
        var valueEnd = input.IndexOf(" ", tagStart);
        return valueEnd != -1
            ? input.Substring(tagStart + tag.Length, valueEnd - tagStart - tag.Length)
            : input.Substring(tagStart + tag.Length);
    }
    public static string UsingLinq(string input) => input
        .Split(' ')
        .Where(x => x.Contains("VersionName"))
        .SelectMany(x => x.Split('='))
        .LastOrDefault();
    public static string UsingRegex(string input) => Regex
        .Match(input, "VersionName=(?<version>\\S*)")
        .Groups.TryGetValue("version", out var group)
        ? group.Value
        : null;
}
Here's test cases I'm checking:
public static class TestCases
{
    public const string Original = "Name=test VersionCode=Azure VersionName=3.2 Package=2.6 Apk=temp";
    public const string EndsWithVersion = "Name=test VersionCode=Azure VersionName=3.2";
    public const string DoesNotHaveVersion = "Name=test VersionCode=Azure";
}
Here's my unit-tests to prove these solutions work:
[TestFixture]
public class StringExtractTests
{
    private const string correctResult = "3.2";
    
    [Test]
    [TestCase(TestCases.Original, correctResult)]
    [TestCase(TestCases.EndsWithVersion, correctResult)]
    [TestCase(TestCases.DoesNotHaveVersion, null)]
    public void IndexOfWorks(string input, string expectedOutput) 
        => Assert.AreEqual(Solutions.UsingIndexOf(input), expectedOutput);
    
    [Test]
    [TestCase(TestCases.Original, correctResult)]
    [TestCase(TestCases.EndsWithVersion, correctResult)]
    [TestCase(TestCases.DoesNotHaveVersion, null)]
    public void LinqWorks(string input, string expectedOutput) 
        => Assert.AreEqual(Solutions.UsingLinq(input), expectedOutput);
    
    [Test]
    [TestCase(TestCases.Original, correctResult)]
    [TestCase(TestCases.EndsWithVersion, correctResult)]
    [TestCase(TestCases.DoesNotHaveVersion, null)]
    public void RegexWorks(string input, string expectedOutput) 
        => Assert.AreEqual(Solutions.UsingRegex(input), expectedOutput);
}
And the fun part, let's compare these solutions performance-wise. I'm using `BenchmarkDotNet` for this:
|       Method |                Input |      Mean |     Error |    StdDev | Ratio |
|------------- |--------------------- |----------:|----------:|----------:|------:|
| UsingIndexOf | DoesNotHaveVersion   | 254.05 ns | 0.1575 ns | 0.1396 ns |  1.00 |
|    UsingLinq | DoesNotHaveVersion   | 282.67 ns | 0.9144 ns | 0.8554 ns |  1.11 |
|   UsingRegex | DoesNotHaveVersion   | 358.67 ns | 1.0870 ns | 0.9636 ns |  1.41 |
|              |                      |           |           |           |       |
| UsingIndexOf | EndsWithVersion      | 126.08 ns | 0.1881 ns | 0.1759 ns |  1.00 |
|    UsingLinq | EndsWithVersion      | 152.85 ns | 0.6277 ns | 0.5871 ns |  1.21 |
|   UsingRegex | EndsWithVersion      |  68.06 ns | 0.5199 ns | 0.4863 ns |  0.54 |
|              |                      |           |           |           |       |
| UsingIndexOf | Original             | 251.91 ns | 0.2094 ns | 0.1856 ns |  1.00 |
|    UsingLinq | Original             | 327.94 ns | 0.3110 ns | 0.2597 ns |  1.30 |
|   UsingRegex | Original             | 372.75 ns | 2.0129 ns | 1.8829 ns |  1.48 |
Looks like, for your original and intended input, IndexOf is the fastest. It is also the least readable, so make your choice.
So yeah, hopefully that helps and you've learned something :-)

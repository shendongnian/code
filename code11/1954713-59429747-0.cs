public class XUnitTestOutputAssertionStrategy : IAssertionStrategy
{
	private readonly ITestOutputHelper output;
	private readonly List<string> failures = new List<string>();
	public XUnitTestOutputAssertionStrategy(ITestOutputHelper output)
	{
		this.output = output;
	}
	public void HandleFailure(string message)
	{
		failures.Add(message);
	}
	public IEnumerable<string> DiscardFailures()
	{
		var snapshot = failures.ToArray();
		failures.Clear();
		return snapshot;
	}
	public void ThrowIfAny(IDictionary<string, object> context)
	{
		if (!failures.Any()) return;
		var sb = new StringBuilder();
		sb.AppendLine(string.Join(Environment.NewLine, failures));
		foreach ((string key, object value) in context)
			sb.AppendFormat("\nWith {0}:\n{1}", key, value);
		output.WriteLine(sb.ToString());
	}
	public IEnumerable<string> FailureMessages => failures;
}
public class ContrivedTests
{
	private readonly ITestOutputHelper output;
	public ContrivedTests(ITestOutputHelper output)
	{
		this.output = output;
	}
	[Fact]
	public void WhenRunningTest_WithContrivedExample_ShouldOutputThenAssert()
	{
		using (new AssertionScope(new XUnitTestOutputAssertionStrategy(output)))
		{
			"Failures will log".Should().Contain("nope", "because we want to log this");
			"Success won't log".Should().StartWith("Success", "because we want to log this too, but it succeeded");
		}
		"This line will fail the test".Should().StartWith("Bottom Text", "because I pulled a sneaky on ya");
	}
}

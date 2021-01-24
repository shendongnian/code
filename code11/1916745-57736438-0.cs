public class Certificate
{
	public Certificate(string value)
	{
		Value = value;
	}
	public string Value { get; }
}
private static string ReadFile(ServiceOptions options)
{
	return File.ReadAllText(options.SomePath);
}
Then you can just register that as a singleton and inject it into your MyService implementation:
builder.Register(context =>
	{
		var options = context.Resolve<ServiceOptions>();
		var data = ReadFile(options);
		return new Certificate(options.SomePath);
	})
	.As<Certificate>()
	.SingleInstance();

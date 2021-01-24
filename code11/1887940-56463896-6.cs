sealed class GenericFactory<TKey, TOption, TObject>
{
	readonly IReadOnlyDictionary<TKey, Func<TKey, TOption, TObject>> _factories;
	public GenericFactory(
		IReadOnlyDictionary<TKey, Func<TKey, TOption, TObject>> factories)
	{
		_factories = factories;
	}
	public bool TryCreate(TKey key, TOption option, out TObject @object)
	{
		@object = default;
		if (!_factories.TryGetValue(key, out var factory))
			return false; // Cannot create; unknown key
		@object = factory(key, option);
		return true;
	}
}
static class GenericFactoryExtensions
{
	public static TObject CreateOrFail<TKey, TOption, TObject>(
		this GenericFactory<TKey, TOption, TObject> factory,
		TKey key,
		TOption option)
	{
		if (!factory.TryCreate(key, option, out var @object))
			throw new NotImplementedException($"Not Recognized or Not Registered in {nameof(GenericFactory<TKey, TOption, TObject>)}");
		return @object;
	}
}
class Factories
{
	public Func<string, ILogger, BaseParser> BaseParserFactory { get; }
	public Func<string, ILogger, IBulkImport> BulkImportFactory { get; }
	public Func<string, ILogger, SomethingElse> SomethingElseFactory { get; }
	public Factories(
		Func<string, ILogger, BaseParser> baseParserFactory,
		Func<string, ILogger, IBulkImport> bulkImportFactory,
		Func<string, ILogger, SomethingElse> somethingElseFactory)
	{
		BaseParserFactory = baseParserFactory;
		BulkImportFactory = bulkImportFactory;
		SomethingElseFactory = somethingElseFactory;
	}
}
void UseFactory()
{
	var mappedFactories = new Dictionary<string, Factories>
	{
		["A"] = new Factories(
			baseParserFactory: (key, logger) => new AParser(logger),
			bulkImportFactory: (key, logger) => new ABulkImport(logger),
			somethingElseFactory: (key, logger) => new ASomethingElse(logger)),
		["B"] = new Factories(
			baseParserFactory: (key, logger) => new BParser(logger),
			bulkImportFactory: (key, logger) => new BBulkImport(logger),
			somethingElseFactory: (key, logger) => new BSomethingElse(logger))
	};
	var baseParserFactory = new GenericFactory<string, ILogger, BaseParser>(
		mappedFactories.ToDictionary(
			keySelector: kvp => kvp.Key,
			elementSelector: kvp => kvp.Value.BaseParserFactory));
	var bulkImportFactory = new GenericFactory<string, ILogger, IBulkImport>(
		mappedFactories.ToDictionary(
			keySelector: kvp => kvp.Key,
			elementSelector: kvp => kvp.Value.BulkImportFactory));
	var somethingElseFactory = new GenericFactory<string, ILogger, SomethingElse>(
		mappedFactories.ToDictionary(
			keySelector: kvp => kvp.Key,
			elementSelector: kvp => kvp.Value.SomethingElseFactory));
	var parser = baseParserFactory.CreateOrFail("A", logger);
	parser.DoStuff();
}
The `Factories` class is what enforces that when there's a `BaseParser` for "A" then there's also a `IBulkImport` and a `SomethingElse`. When you want the compile-time guarantee that you can also create a `YetAnotherThing` for all cases then just add that as a required property of the `Factories` class and create a new `GenericFactory` according to the pattern.
When you want to add functionality for "C" then all you have to do is add another entry in the `mappedFactories` dictionary.
Can this be abstracted further? I think so, but I suspect it would come without the compile-time guarantee that when you can create a `BaseParser` then you can also create a `IBulkImport`.
You might be helped to develop a sense of smell for `switch` statements (that by definition are not Open for extension/Closed for modification, also known as the Open/Closed principle) which need to be modified to extend functionality. Composing with dictionaries is often the solution. Same for endless `if` statements.
Notice that my `GenericFactory` is `sealed` and missing the `abstract` keyword. That's intentional. Consumers of this factory should be composed of this factory instead of inheriting from it. Just like the `UseFactory` method composes instances of the factory instead of instances of things that inherit from it. That's another principles at play: favor composition over inheritance.
You'll also notice that the `GenericFactory` is really a factory that is composed of other factories&mdash;it delegates to other factories (each `Func` in the injected dictionary is itself a factory). If you truly need this then that signals to me that you probably aren't using an IoC container, because IoC containers typically give this mechanism of composing factories without you having to use this. In that case you might be helped to investigate IoC containers.

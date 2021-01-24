sealed class GenericFactory<TObject, TKey, TOption>
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
void UseFactory()
{
	var factory = new GenericFactory<string, BaseParser, ILogger>(new Dictionary<string, BaseParser>
		{
			["A"] = (key, logger) => new AParser(logger),
			["B"] = (key, logger) => new BParser(logger)
		});
	if (!factory.TryCreate("A", logger, out var parser))
		throw new NotImplementedException();
	parser.DoStuff();
}
You might be helped to develop a sense of smell for `switch` statements (that by definition are not Open for extension/Closed for modification) which need to be modified to extend functionality. Composing with dictionaries is often the solution. Same for endless `if` statements.
Notice that my `GenericFactory` is sealed... it's missing the `abstract` keyword. That's intentional. Consumers of this factory should be composed of this factory instead of inheriting from it. Another principle at play: favor composition over inheritance.

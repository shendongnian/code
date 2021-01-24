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
void SimpleUseFactory()
{
	var baseParserFactory = new GenericFactory<string, ILogger, BaseParser>(new Dictionary<string, Func<string, ILogger, BaseParser>>
		{
			["A"] = (key, logger) => new AParser(logger),
			["B"] = (key, logger) => new BParser(logger)
		});
	var parser = baseParserFactory.CreateOrFail("A", logger);
	parser.DoStuff();
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
void ComplexUseFactory()
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
For the "complex" use case demonstrated:
The `Factories` class is what enforces that when there's a `BaseParser` for "A" then there's also a `IBulkImport` and a `SomethingElse`. When you want the compile-time guarantee that you can also create a `YetAnotherThing` for all cases then just add that as a required property of the `Factories` class and create a new `GenericFactory` according to the pattern.
When you want to add functionality for "C" then all you have to do is add another entry in the `mappedFactories` dictionary.
Note that the `mappedFactories` could be instantiated and then tossed around between different modules in order to populate it with all the necessary "A", "B", "C", etc cases before creating the `GenericFactory`s. Or instead of making the modules accept a `Dictionary<string, Factories>` object, maybe each module could have an implementation of an interface that generates just one `Factories` instance and you could gather the "A", "B", etc keys from module metadata. That way you could guarantee that the "B" module doesn't mess with "A" module's factories.
Can this be abstracted further? I think so, but I suspect it would come without the compile-time guarantee that when you can create a `BaseParser` then you can also create a `IBulkImport`.
For both cases:
You might be helped to develop a sense of smell for `switch` statements (that by definition are not Open for extension/Closed for modification, also known as the Open/Closed principle) which need to be modified to extend functionality. Composing with dictionaries is often the solution. Same for endless `if` statements.
Notice that the `GenericFactory` is `sealed` and missing the `abstract` keyword. That's intentional. Consumers of this factory should be composed of this factory instead of inheriting from it. Just like the `UseFactory` method composes instances of the factory instead of instances of things that inherit from it. That's another principle at play: favor composition over inheritance.
You'll also notice that the `GenericFactory` is really a factory that is composed of other factories&mdash;it delegates to other factories (each `Func` in the injected dictionary is itself a factory). If you truly need this then that signals to me that you probably aren't using an IoC container, because IoC containers typically give this mechanism of composing factories without you having to use this. In that case you might be helped to investigate IoC containers.
---
Edit: [You](https://stackoverflow.com/questions/56463163/how-to-create-a-generic-factory-returning-different-interface-types-and-an-abstr/56463896?noredirect=1#comment99647686_56463896) and I both mentioned something about IoC.
If I had IoC, I would try really hard to get to the following scenario so that I wouldn't even need `GenericFactory`.
(My apologies in advance for making up pseudocode that doesn't work out of the box for any known IoC container)
**ModuleA.cs**
Register<AParser>().As<BaseParser>();
Register<ABulkImport>().As<IBulkImport>();
**ModuleB.cs**
Register<BParser>().As<BaseParser>();
Register<BBulkImport>().As<IBulkImport>();
**CommonThing.cs**
public class CommonThing
{
	readonly BaseParser _parser;
	readonly IBulkImport _bulkImport;
    public CommonThing(
        BaseParser parser,
        IBulkImport bulkImport)
    {
    	_parser = parser;
    	_bulkImport = bulkImport;
    }
    public void DoFancyStuff(string data)
    {
    	var parsed = _parser.Parse(data);
    	_bulkImport.Import(parsed);
    }
}
**Single Composition Root**
switch (module)
{
    case "A":
        RegisterModule<ModuleA>();
        break;
    case "B":
        RegisterModule<ModuleB>();
        break;
    default:
        throw new NotImplementedException($"Unexpected module {module}");
}
Register<CommonThing>();
Register<Application>();
**Application.cs**
public class Application
{
    readonly CommonThing _commonThing;
    public Application(
        CommonThing commonThing)
    {
        _commonThing = commonThing;
    }
    public void Run()
    {
        var json = "{\"key\":\"value\"}";
        _commonThing.DoFancyStuff(json);
    }
}
**Program.cs** (or entry point of your choice)
var containerBuilder = new IoCBuilder();
containerBuilder.RegisterModule<SingleCompositionRoot.cs>();
using (var container = containerBuilder.Build())
    container.Resolve<Application>().Run();
Note: the Single Composition Root often doesn't have to obey Open/Closed. But if you'd like the `switch` statement there to go away then one could move toward this kind of design:
**ModuleNameAttribute.cs**
public class ModuleNameAttribute : Attribute
{
    public string Name { get; }
    ...
}
**ModuleA.cs**
[ModuleName("A")]
public class ModuleA
{
    ...
}
**ModuleB.cs**
[ModuleName("B")]
public class ModuleB
{
    ...
}
**Single Composition Root**
var moduleType = GetAllTypesInAppDomain()
    .Select(type => (type, type.GetCustomAttribute<ModuleNameAttribute>()))
    .Where(tuple => tuple.Item2 != null)
    .Where(tuple => tuple.Item2.Name == module)
    .FirstOrDefault();
if (moduleType == null)
    throw new NotImplementedException($"No module has a {nameof(ModuleNameAttribute)} matching the requested module {module}");
RegisterModule(moduleType);
...
Note that one of the benefits of going all the way with Dependency Injection (meaning register/resolve the application itself like `Program.cs` does above) is that missing registrations cause _very early_ runtime exceptions. This often eliminates the need for some kind of compile-time guarantee that all the correct things are in the correct places.
For example, if `module` were defined as "C" then that `NotImplementedException` in "Single Composition Root" would be thrown at application launch. Or if module C does exist but fails to register an implementation of `IBulkImport` then the IoC container would throw a runtime exception while trying to resolve `CommonThing` for `Application`, again at application launch. So if the application launches then you know that all dependencies either were resolved or can be resolved.

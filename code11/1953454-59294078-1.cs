cs
var baseType = typeof(Extractor<>).MakeGenericType(typeof(Unchangeable));
var extractorType = Assembly.GetExecutingAssembly()
	.GetTypes().FirstOrDefault(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(baseType));
if (extractorType != null)
{
	dynamic extractor = Activator.CreateInstance(extractorType);
	extractor.ExtractionOne(new Unchangeable());
}
Of course, it's simplified, you can pass an specific instance of `Unchangeable` or `Untouchable` class and restrict assembly types scanning (and get all types only once). 
The disadvantage here is that you have to pay attention to `ExtractionOne` and `ExtractionTwo` signatures, since they are invoked on dynamic object
> The core issue with this approach is that it's unfortunately looking
> for a class of the form `Extractor<>` instead of an interface of the
> form `IExtractor<>`.
This snippet can help you to look through types using `IExtrator<>` interface
cs
var baseType = typeof(IExtractor<>).MakeGenericType(typeof(Unchangeable));
var extractorType = Assembly.GetExecutingAssembly()
	.GetTypes().FirstOrDefault(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t));

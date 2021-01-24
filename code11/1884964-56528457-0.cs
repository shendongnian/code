c#
public class ObjectA
{
    public int Index { get; set; }
    public int Pages { get; set; }
    public string MyProperty { get; set; }
}
And for `ViewModelA` we want to resolve `StartPage`, based on the properties of the previous `ObjectA`'s.
c#
public class ViewModelA
{
    public int StartPage { get; set; }
    public string MyProperty { get; set; }
}
We can clean up your current approach using extension methods.
c#
public static class AutoMapperExt
{
    public static TDestination MapWithSource<TSource, TDestination>(this IMapper mapper, TSource source)
        => mapper.Map<TSource, TDestination>(source, opts => opts.Items[typeof(TSource).ToString()] = source);
    public static TSource GetSource<TSource>(this ResolutionContext context)
        => (TSource)context.Items[typeof(TSource).ToString()];
}
Using these methods we no longer need to handle the context's `Items` collection directly.
c#
class Program
{
    static void Main(string[] args)
    {
        var config =
            new MapperConfiguration(cfg =>
                cfg.CreateMap<ObjectA, ViewModelA>()
                   .ForMember(dest => dest.StartPage, opt => opt.MapFrom<CustomResolver, int>(src => src.Index))
            );
        var mapper = config.CreateMapper();
        var source = new List<ObjectA>
        {
            new ObjectA { Index = 0, Pages = 3, MyProperty = "Foo" },
            new ObjectA { Index = 1, Pages = 2, MyProperty = "Bar" },
            new ObjectA { Index = 2, Pages = 1, MyProperty = "Foz" },
        };
        var result = mapper.MapWithSource<List<ObjectA>, List<ViewModelA>>(source);
        result.ForEach(o => Console.WriteLine(o.StartPage)); // prints 1,4,6
        Console.ReadKey();
    }
}
public class CustomResolver : IMemberValueResolver<object, object, int, int>
{
    public int Resolve(object source, object destination, int sourceMember, int destMember, ResolutionContext context)
    {
        var index = sourceMember;
        var list = context.GetSource<List<ObjectA>>();
        var pages = 1;
        for (int i = 0; i < index; i++)
        {
            pages += list[i].Pages;
        }
        return pages;
    }
}
If you want to reuse `CustomResolver` on different classes, you can abstract the properties it operates on into an interface.
c#
public interface IHavePages
{
    int Index { get; }
    int Pages { get; }
}
public class ObjectA : IHavePages
{
    public int Index { get; set; }
    public int Pages { get; set; }
    public string MyProperty { get; set; }
}
This way the resolver is no longer bound to a concrete implementation. We can now even use the interface as a type parameter.
c#
public class CustomResolver : IMemberValueResolver<IHavePages, object, int, int>
{
    public int Resolve(IHavePages source, object destination, int sourceMember, int destMember, ResolutionContext context)
    {
        var hasPages = source;
        var index = sourceMember;
        var list = context.GetSource<List<IHavePages>>();
        var pages = 1;
        for (int i = 0; i < index; i++)
        {
            pages += list[i].Pages;
        }
        return pages;
    }
}
All we need to do is transform our `List<ObjectA>` before mapping.
c#
var listOfObjectA = new List<ObjectA>
{
    new ObjectA { Index = 0, Pages = 3, MyProperty = "Foo" },
    new ObjectA { Index = 1, Pages = 2, MyProperty = "Bar" },
    new ObjectA { Index = 2, Pages = 1, MyProperty = "Foz" },
};
var source = listOfObjectA.OfType<IHavePages>().ToList();
var result = mapper.MapWithSource<List<IHavePages>, List<ViewModelA>>(source);
// AutoMapper still maps properties that aren't part of the interface
result.ForEach(o => Console.WriteLine($"{o.StartPage} - {o.MyProperty}"));
Once you code to an interface, the `sourceMember` in the `CustomResolver` becomes redundant. We can now get it through the passed `source`. Allowing for one final refactor, as we derive from `IValueResolver` instead of `IMemberValueResolver`.
c#
public class CustomResolver : IValueResolver<IHavePages, object, int>
{
    public int Resolve(IHavePages source, object destination, int destMember, ResolutionContext context)
    {
        var list = context.GetSource<List<IHavePages>>();
        var pages = 1;
        for (int i = 0; i < source.Index; i++)
        {
            pages += list[i].Pages;
        }
        return pages;
    }
}
Updating the signature.
c#
cfg.CreateMap<ObjectA, ViewModelA>()
   .ForMember(dest => dest.StartPage, opt => opt.MapFrom<CustomResolver>())
How far you take it is entirely up to you, but you can improve code reuse by introducing abstractions.

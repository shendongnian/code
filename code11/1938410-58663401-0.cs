readonly struct Option<T> 
{
    public readonly T Value {get;}
    
    public readonly bool IsSome {get;}
    public readonly bool IsNone =>!IsSome;
    public Option(T value)=>(Value,IsSome)=(value,true);    
    public void Deconstruct(out T value)=>(value)=(Value);
}
//Convenience methods, similar to F#'s Option module
static class Option
{
    public static Option<T> Some<T>(T value)=>new Option<T>(value);    
    public static Option<T> None<T>()=>default;
    ...
}
**Should** allow code like this :
    static string Test(Option<MyClass> opt = default)
    {
        return opt switch
        {
                Option<MyClass> { IsNone: true } => "None",                
                Option<MyClass> (var v)          => $"Some {v.SomeText}",
        };
    }
The first option uses property pattern matching to check for `None`, while the second one uses positional pattern matching to actually extract the value through the deconstructor.
The nice thing is that the compiler recognizes this as an exhaustive match so we don't need to add a default clause. 
Unfortunately, a Roslyn bug [prevents this](https://github.com/dotnet/roslyn/issues/38121). The linked issue actually tries to create an Option<T> *class* based on an abstract base class. This was [fixed in VS 2019 16.4 Preview 1](https://github.com/dotnet/roslyn/pull/37898). 
The fixed compiler allows us to omit the parameter or pass a `None` :
    class MyClass
    {
        public string SomeText { get; set; } = "";
    }
    ...
    Console.WriteLine( Test() );
    Console.WriteLine( Test(Option.None<MyClass>()) );
    var c = new MyClass { SomeText = "Cheese" };
    Console.WriteLine( Test(Option.Some(c)) );
This produces :
None
None
Some Cheese
VS 2019 16.4 should come out at the same time as .NET Core 3.1 in a few weeks.
Until then, an uglier solution could be to return `IsSome` in the deconstructor and use positional pattern matching in both cases: 
public readonly struct Option<T> 
{
    public readonly T Value {get;}
    
    public readonly bool IsSome {get;}
    public readonly bool IsNone =>!IsSome;
    public Option(T value)=>(Value,IsSome)=(value,true);    
    public void Deconstruct(out T value,out bool isSome)=>(value,isSome)=(Value,IsSome);
    public void Deconstruct(out T value)=>(value)=(Value);
}
And 
    return opt switch {  Option<MyClass> (_    ,false)  =>"None",
                         Option<MyClass> (var v,true)   => $"Some {v.SomeText}" ,                };
**Borrowing from F# Options**
No matter which technique we use, we can add extension methods to the `Option` static class that mimic F#'s [Option module](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/options#option-module), eg Bind, perhaps the most useful method, applies a function to an Option<T> if it has a value and returns an Option<U>, or returns None if there's no value :
    public static Option<U> Bind<T,U>(this Option<T> inp,Func<T,Option<U>> func)
    {
        return inp switch {  Option<T> (_    ,false)  =>Option.None<U>(),
                             Option<T> (var v,true)   => func(v) ,                         
                           };
    }
For example this applies the `Format` method to an Option<MyClass> to create a Optino<string> :
Option<string> Format(MyClass c)
{
    return Option.Some($"Some {c.SomeText}");
}
var c=new MyClass { SomeText = "Cheese"};
var opt=Option.Some(c);
var message=opt.Bind(Format);
This makes it easy to create other helper functions, or chain functions that produce options

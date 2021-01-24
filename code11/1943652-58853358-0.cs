type Result<'T,'TError> =
    | Ok of ResultValue:'T
    | Error of ErrorValue:'TError
The types themselves only carry what they need.
DUs in F# allow exhaustive pattern matching without requiring nulls :
    match res2 with
    | Ok req -> printfn "My request was valid! Name: %s Email %s" req.Name req.Email
    | Error e -> printfn "Error: %s" e
**Emulating this in CE 8**
Unfortunately, C# 8 doesn't have DUs yet, they're scheduled for C# 9. In C# 8 we can emulate this, but we lose exhaustive matching :
#nullable enable
public interface IResult<TResult,TError>{}​
​struct Success<TResult,TError> : IResult<TResult,TError>
{
    public TResult Value {get;}
    
    public Success(TResult value)=>Value=value;
    
    public void Deconstruct(out TResult value)=>value=Value;        
}
​struct Error<TResult,TError> : IResult<TResult,TError>
{
    public TError ErrorValue {get;}
    public Error(TError error)=>ErrorValue=error;
    public void Deconstruct(out TError error)=>error=ErrorValue;
}
And use it :
IResult<double,string> Sqrt(IResult<double,string> input)
{
    return input switch {
        Error<double,string> e => e,
        Success<double,string> (var v) when v<0 => new Error<double,string>("Negative"),
        Success<double,string> (var v)  => new Success<double,string>(Math.Sqrt(v)),
        _ => throw new ArgumentException()
    };
}
Without exhaustive pattern matching, we have to add that default clause to avoid compiler warnings.
I'm still looking for a way to get exhaustive matching *without* introducing dead values, even if they are just an Option<T>. 
**Option/Maybe**
Creating an Option<T> class by the way that uses exhaustive matching is simpler :
readonly struct Option<T> 
{
    public readonly T Value {get;}
    public readonly bool IsSome {get;}
    public readonly bool IsNone =>!IsSome;
    public Option(T value)=>(Value,IsSome)=(value,true);    
    public void Deconstruct(out T value,out bool isSome)=>(value,isSome)=(Value,IsSome);
}
//Convenience methods, similar to F#'s Option module
static class Option
{
    public static Option<T> Some<T>(T value)=>new Option<T>(value);    
    public static Option<T> None<T>()=>default;
}
Which can be used with :
string cateGory = someValue switch { Option<Category> (_    ,false) =>"No Category",
                                     Option<Category> (var v,true)  => v.Name
                                   };

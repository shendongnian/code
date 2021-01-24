var message=result switch { {IsSuccess:true,Data:var data} => $"Got some: {data}",
                            {IsSuccess:false,Description:var error} => $"Oops {error}",
             };  
If your methods accept and return `IResult<T>` objects, you could write something like :
IResult<string> Doubler(IResult<string> input)
{
    return input switch { {IsSuccess:true,Data:var data} => new Ok<string>(data+ "2"),
                          {IsSuccess:false} => input
    };  
}
...
var result2=new Ok<string>("3");
var message2=Doubler(result2) switch { 
                     {IsSuccess:true,Data:var data} => $"Got some: {data}",
                     {IsSuccess:false,Description:var error} => $"Oops {error}",
             };  
---
**Original Answer**
It looks like the *real* problem is the implementation of the [Result](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/results) pattern. This pattern has two characteristics :
- It prevents the use of invalid result values at the type level. It does this by It uses two different types to represent good and bad results. By doing so, each type only carries what it needs. 
- It forces the clients to handle all cases or explicitly ignore them. 
Some languages like Rust have a built-in type for this. Functional languages that support option types/discriminated unions like F#, can easily implement it with just :
type Result<'T,'TError> =
    | Ok of ResultValue:'T
    | Error of ErrorValue:'TError
Exhaustive pattern matching means clients have to handle both cases. That type is so common though, it made it into the language itself. 
**C# 8**
In C# 8 we can implement the two types, without the exhaustive pattern matching. For now, the types need a common class, either an interface or abstract class, which doesn't really need to have any members. There are many ways to implement them, eg :
public interface IResult<TSuccess,TError>{}
public class Ok<TSuccess,TError>:IResult<TSuccess,TError>
{
    public TSuccess Data{get;}
    public Ok(TSuccess data)=>Data=data;
    public void Deconstruct(out TSuccess data)=>data=Data;
}
public class Fail<TSuccess,TError>:IResult<TSuccess,TError>
{
    public TError Error{get;}
    public Fail(TError error)=>Error=error;
    public void Deconstruct(out TError error)=>error=Error;
}
We could use structs instead of classes. 
Or, to use a syntax closer to C# 9's discriminated unions, the classes can be nested. The type can still be an interface, but I really don't like writing `new IResult<string,string>.Fail` or naming an interface `Result` instead of `IResult` :
public abstract class Result<TSuccess,TError>
{
    public class Ok:Result<TSuccess,TError>
    {
        public TSuccess Data{get;}
        public Ok(TSuccess data)=>Data=data;
        public void Deconstruct(out TSuccess data)=>data=Data;
    }
    
    public class Fail:Result<TSuccess,TError>
    {
       public TError Error{get;}
        public Fail(TError error)=>Error=error;
        public void Deconstruct(out TError error)=>error=Error;
    }
    
    //Convenience methods
    public static Result<TSuccess,TError> Good(TSuccess data)=>new  Ok(data);
    public static Result<TSuccess,TError> Bad(TError error)=>new  Fail(error);
}
We can use pattern matching to handle `Result` values. Unfortunatelly, C# 8 doesn't offer exhaustive matching so we need to add a default case too.
    var result=Result<string,string>.Bad("moo");
    var message=result switch { Result<string,string>.Ok (var Data) => $"Got some: {Data}",
                                Result<string,string>.Fail (var Error) => $"Oops {Error}"
                                _ => throw new InvalidOperationException("Unexpected result case")
                          };
**C# 9**
C# 9 is (probably) going to add discriminated unions through [enum classes](https://github.com/dotnet/csharplang/blob/master/proposals/discriminated-unions.md). We'll be able to write :
enum class Result
{
    Ok(MySuccess Data),
    Fail(MyError Error)
}
and use it through pattern matching. This syntax already works in C# 8 as long as there's a matching deconstructor. C# 9 will add exhaustive matching and probably simplify the syntax too  :
var message=result switch { Result.Ok (var Data) => $"Got some: {Data}",
                            Result.Fail (var Error) => $"Oops {Error}"
                          };
**Updating the existing type through DIMs**
Some of the existing functions like `IsSuccess` and `Outcome` are just convenience methods. In fact, F#'s option types also expose the "kind" of the value as a *tag* . We can add such methods to the interface and return a fixed value from the implementations :
public interface IResult<TSuccess,TError>
{
    public bool IsSuccess {get;}
    public bool IsFailure {get;}
    public bool ResultOutcome {get;}
}
public class Ok<TSuccess,string>:IResult<TSuccess,TError>
{
    public bool IsSuccess     =>true;
    public bool IsFailure     =>false;
    public bool ResultOutcome =>ResultOutcome.Success;
    ...
}
The `Description` and `Data` properties can be implemented too, as a stop gap measure - they break the Result pattern and pattern matching makes them obsolete anyway :
public class Ok<TSuccess,TError>:IResult<TSuccess,TError>
{
    ...
    public TError Description=>throw new InvalidOperationException("A Success Result has no Description");
    ...
}
Default interface members can be used to avoid littering the concrete types :
public interface IResult<TSuccess,TError>
{
    //Migration methods
    public TSuccess Data=>
        (this is Ok<TSuccess,TError> (var Data))
        ?Data
        :throw new InvalidOperationException("An Error has no data");
    public TError Description=> 
        (this is Fail<TSuccess,TError> (var Error))
        ?Error
        :throw new InvalidOperationException("A Success Result has no Description");
    //Convenience methods
    public static IResult<TSuccess,TError> Good(TSuccess data)=>new  Ok<TSuccess,TError>(data);
    public static IResult<TSuccess,TError> Bad(TError error)=>new  Fail<TSuccess,TError>(error);
}
**Modifications to add exhaustive matching**
We could avoid the default cases in the pattern matching exceptions if we use only *one* flag and the migration properties :
public interface IResult<TSuccess,TError>
{
    public bool IsSuccess{get;}
    public bool IsFailure=>!IsSuccess;
    //Migration methods
    ...
}
var message2=result switch { {IsSuccess:true,Data:var data} => $"Got some: {data}",
                             {IsSuccess:false,Description:var error} => $"Oops {error}",
             };  
This time, the compiler detects there are only two cases, and both are covered. The migration properties allow the compiler to retrieve the correct type. The consuming code has to change *and* use the correct pattern, but I suspect it already worked that 

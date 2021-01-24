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

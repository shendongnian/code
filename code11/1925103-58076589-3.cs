type Result<'T,'TError> = 
    | Ok of ResultValue:'T 
    | Error of ErrorValue:'TError
We can't do that in C# 8 yet, because there are no discriminated unions. Those are planned for C# 9.
**Pattern Matching**
What we *can* do, is use pattern matching to get the same behavior eg:
interface IResult<TResult,TError>{} //No need for an actual implementation
public class Success<TResult,TError>:IResult<TResult,TError>
{
    public TResult Result {get;}
    public Success(TResult result) { Result=result;}
}
public class Error<TResult,TError>:IResult<TResult,TError>
{
    public TError ErrorValue {get;}
    public Error(TError error) { ErrorValue=error;}
}
This way there's no way to create an `IResult<>` that is both a success and error. This can be used with pattern matching, eg:
IResult<int,string> someResult=.....;
if(someResult is Success<int,string> s)
{
    //Use s.Result here
}
**Simplifying the expressions**
Given C# 8's [property patterns](https://devblogs.microsoft.com/dotnet/do-more-with-patterns-in-c-8-0/), this could be rewritten as :
if(someResult is Success<int,string> {Result: var result} )
{
    Console.WriteLine(result);
}
or, using switch expressions, a typical railway-style call :
IResult<int,string> DoubleIt(IResult<int,string> data)
{
    return data switch {    Error<int,string> e=>e,
                            Success<int,string> {Result: var result}=>
                                new Success<int,string>(result*2),
                            _ => throw new Exception("Unexpected type!")
                            };
}    
F# wouldn't need that `throw` as there's no way that an `Result<'T,'TError>` would be something other than `Ok` or `Error`. In C#, we don't have that feature *yet*. 
The switch expression allows exhaustive matching. I think the compiler will generate a warning if the default clause is missing too.
**With deconstructors**
The expressions can be simplified a bit more if the types have deconstructors, eg:
public class Success<TResult,TError>:IResult<TResult,TError>
{
    public TResult Result {get;}
    public Success(TResult result) { Result=result;}
    
    public void Deconstruct(out TResult result) { result=Result;}
}
public class Error<TResult,TError>:IResult<TResult,TError>
{
    public TError ErrorValue {get;}
    public Error(TError error) { ErrorValue=error;}
    
    public void Deconstruct(out TError error) { error=ErrorValue;}
}
In that case the expression can be written as :
    return data switch {    
                    Error<int,string> e => e,
                    Success<int,string> (var result) => new Success<int,string>(result*3),
                    _ => throw new Exception("Unexpected type!")
    };

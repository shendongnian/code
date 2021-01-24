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
**Nullability**
The question started with nullable reference types, so what about nullability? Will we get a warning in C# 8 if we try to pass a nulll?
Yes, as long as NRTs are enabled. This code :
#nullable enable
void Main()
{
     IResult<string,string> data=new Success<string,string>(null);
     var it=Append1(data);
     Console.WriteLine(it);
}
IResult<string,string> Append1(IResult<string,string> data)
{
    return data switch {    Error<string,string> e=>e,
                            Success<string,string> (var result)=>
                                new Success<string,string>(result+"1"),
                            _ => throw new Exception("Unexpected type!")
                            };
}
Genereates `CS8625: Cannot convert null literal to non-nullable reference type`
Trying 
string? s=null;
IResult<string,string> data=new Success<string,string>(s);
Generates `CS8604: Possible null reference argument ....`

public class ReturnResult
{
    public ReturnResult(bool state, string message)
    {
        IsSuccess = state;
        ErrorMessage = message;
    }
    public bool IsSuccess
    {
        get;
        private set;
    }
    public string ErrorMessage
    {
        get;
        private set;
    }
    public static bool operator true(ReturnResult returnResult) => 
        returnResult.IsSuccess;
    public static bool operator false(ReturnResult returnResult) => 
        !returnResult.IsSuccess;    // Alternatively, implement as
                                    // returnResult ? false : true,
                                    // avoiding duplication.
}
You also have to define a matching `false` operator. Now these lines will work:
ReturnResult rr = CallSomeFunction(a,b,c);
if (rr) // Succeeds if the operator returns true, so if rr.IsSuccess is true.
{
    // If it's good.
}
else 
{
    // If it's bad.
}
EDIT:
As Dmitry suggested, it's probably worth mentioning that you can also override the implicit conversion operator to `bool`:
csharp
public static implicit operator bool(ReturnResult returnResult) => 
    returnResult.IsSuccess;
While `true` and `false` are used in Boolean Expressions[^1], which at the time of this writing are limited to control statements and the `?:` ternary operator, the implicit conversion operator will also allow assignments like this:
csharp
ReturnResult rr = CallSomeFunction(a,b,c);
bool b = rr;
You might wonder which one is used in an `if` statement if all three of them are overloaded - the answer is that [the implicit conversion takes precedence, as per the spec](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#boolean-expressions).
[^1]: And also during `&&` and `||` operators evaluation, if there are user-defined `&` and `|` operators defined on the type. For more info, [the spec is your friend](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#user-defined-conditional-logical-operators).

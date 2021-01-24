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
        !returnResult.IsSuccess;
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

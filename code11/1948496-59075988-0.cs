`
public class CallResponse
{
    public bool Success { get; set; }
    public string Json { get; set; } // this can vary based on  your needs
    public Exception ex { get; set; } // used only if there was an error in the call
}
`
Then, each call would return an instance of `CallResponse`:
`
    CallResponse response1 = Call1();
    if (!response1.Success) 
    {
        HandleError(response1)
        return;
    }
    CallResponse response2 = Call2(response1.Json);
    if (!response2.Success) 
    {
        HandleError(response2)
        return;
    }
`
And so on. I don't know if this fits a known pattern, but at least it keeps the top level code clean and easy to follow.

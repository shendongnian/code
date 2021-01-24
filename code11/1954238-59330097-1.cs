cs
var taskList = new List<Task>();
Task<int?> typeFetcher = null;
if (option is IProcessType t)
{
    typeFetcher = t.GetAsync();
    taskList.Add(typeFetcher);
}
...
await Task.WhenAll(taskList);
if (typeFetcher != null)
{
    Result.TypeId = typeFetcher.Result,
}
...
But you keeping two references to the same thing is... I don't know. Seems like it could be done better.
Another option is to use [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions) that set the value and add that to your task list. That way, you don't have to set the values after awaiting.
cs
public async Task<ProcessResult> Process(TaskOption option)
{
    var taskList = new List<Task>();
    
    // First optional task
    if (option is IProcessType t)
    {
        // Declare a local function that sets the value
        async Task TypeFetcher()
        {
            Result.TypeId = await t.GetAsync();
        }
        // Call it and add the resulting Task to the list
        taskList.Add(TypeFetcher());
    }
    
    // Second optional task
    Task<int?> subtypeFetcher = Task.FromResult<int?>(null);
    if (option is IProcessSubtype st)
    {
        async Task SubtypeFetcher()
        {
            Result.SubtypeId = await st.GetAsync();
        }
        taskList.Add(SubtypeFetcher());
    }
    // Third optional task
    if(Result.Content != null) 
    {
        //don't need a local function here since there's no return value
        taskList.Add(SetMainContentAsync(Result.Content));
    }
    await Task.WhenAll(taskList);
    //I assume you actually declared and set result somewhere
    return result;
}
I'm not saying that's any more efficient than keeping two references to each `Task`. Just do what you find least confusing.

public static async Task<bool> DoSomething()
{
    await Task.Run(() =>
    {
        return AFunctionThatTakesALongTime();
    });
}
is equivalent to the following snippet:
public static async Task<bool> DoSomething()
{
    bool r = await Task.Run(() =>
    {
        return AFunctionThatTakesALongTime();
    });
    // not returning r
}
# Solution 
return await Task.Run(() => ...)

csharp
// this is correct, SocketMessage is the type parameter that Filter expects
private async Task Filter(SocketMessage arg)
{
}
public async Task StartInterpretation()
{
    var arg = new SocketMessage();
    // do not specify the type parameter, just pass the variable
    await Filter(arg);
}

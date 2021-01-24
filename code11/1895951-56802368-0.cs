interface IHandler
{
    void Execute();
} 
class Orange : IHandler 
{
    public void Execute()
    {
        // do your orange stuff 
    }
}
class Tomato : IHandler
{
    public void Execute()
    {
        // do your tomato stuff
    }
}
It can be called like this.
if (msg is IHandler) ((IHandler)msg).Execute();

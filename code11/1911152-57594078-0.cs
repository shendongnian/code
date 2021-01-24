public class UnitTest : IDisposable, IAsyncLifetime
{
    public UnitTest()
    {
        //First
    }
    public Task InitializeAsync()
    {
        //Second
    }
    [Fact]
    public async Task Test1()
    {
        //Third
    }
    public Task DisposeAsync()
    {
        //Forth
    }
    public void Dispose()
    {
        //Fifth
    }
}

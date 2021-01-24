cs
public interface IAsyncDisposable
{
    ValueTask DisposeAsync();
}

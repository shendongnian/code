    public sealed class Foo : IDisposable
    {
        IDisposable boo;
    
        void Dispose()
        {
            boo?.Dispose();
        }
    }

    private class Foo : IDisposable
    {
        IDisposable boo;
    
        public void Dispose()
        {
            boo?.Dispose();
        }
    }

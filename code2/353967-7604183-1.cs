    using (var f = new Foo())
    {
        // something
    }
    
    …
    
    class Foo : IDisposable
    {
        UnmanagedResource m_resource;
    
        public Foo()
        {
            // obtain m_resource
    
            throw new Exception();
        }
    
        public void Dispose()
        {
            // release m_resource
        }
    }

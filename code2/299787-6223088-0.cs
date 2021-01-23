    class SampleC<T> : IDisposable where T : IDisposable // case C
    {    
        public void Dispose()    
        {        
            throw new NotImplementedException();    
        }
    }

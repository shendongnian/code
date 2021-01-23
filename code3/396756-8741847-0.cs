     class IndentedLog : IDisposable
     {
        public IndentedLog() 
        {
           Log.IndentLevel++; 
        }
        public void Dispose() 
        {
           Log.IndentLevel--;
        }
     }

    interface IMyInterace : IDisposable { }
     
    sealed class MyImplementation : IMyInterface 
    {   
       public void Open() { /* instantiates disposible class */ }
     
       public void Close() { /* calls _myField.Dispose(); */ }
     
       public void Dispose() { Close(); }  // only use this short form in a sealed class
     
    }

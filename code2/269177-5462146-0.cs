    public class MyCustomControl: ISupportInitialize
    {
        private bool _initializing = false;
    
        private void BeginInit()
        {
            _initializing = true;
        }
    
        private void EndInit()
        {
            _initializing = false;
        }
    
        private void SomeMethodThatWouldRaiseAnEventDuringInit()
        {
            if (_initializing) return;
            //...
        }
    }

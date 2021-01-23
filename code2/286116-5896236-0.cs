    public class MyBindingSource : ISupportInitialize // + all other interfaces
    {
        private BindingSource _original; // to be set in constructor
        public void BeginInit()
        {
            // custom logic goes here
            _original.BeginInit();
        }
        // ... (all other forwarding implementations)
    }

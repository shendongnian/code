    public class ViewModel
    {
        private static uint instanceCount;
        private readonly uint id;
        private static object _syncRoot = new object();
    
        public ViewModel()
        {
            lock(_syncRoot)
            {
                id = instanceCount++;
            }
        }
    
        public uint DivId
        {
            get { return id; }
        }
    }

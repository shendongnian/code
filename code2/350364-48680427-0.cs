    public class Dock
    {
        // Statik field
        private static Dock _dock;
        // lock object
        private static object lockObject = new object();
        
        // We prevent the constructive method from being modeled with new by 
        //making it secret.
        private Dock()
        {
            
        }
        // Class in Instance
        public static Dock Instance()
        {   
            if (_dock == null)
            {
                lock (lockObject)
                {
                    if (_dock == null)
                        _dock = new Dock();
                }
            }
            return _dock;
        }
}

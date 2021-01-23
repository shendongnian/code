    public class Foo
    {
        public void Start()
        {
            PreCommon();
            // Code [Start]
            PostCommon();
        }
        
        public void Stop()
        {
            PreCommon();
            // Code [Stop]
            PostCommon();
        }
        private void PreCommon()
        {
            // Code [Pre-Common]
        }  
        private void PostCommon()
        {
            // Code [Post-Common]
        }    
        ...
    
    }

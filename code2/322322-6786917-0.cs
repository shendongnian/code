    public abstract class BaseItem
    {
        public int ItemId{get;set;}
        public string ItemName{get;set;}
        /* Add additional properties */
        
        public void PublichSharedMethod()
        {
            /* This method will be publicly available to all derived members and external activators */
        }
    
        protected void PortectedMethod()
        {
            /* This method will be available only to derived classes */
        }
    
        protected virtual ProtectedBaseImplementation()
        {
            /* This method will be available only to derived classes, and they can override its behavior */
        }
    
        public abstract void RequriesImplementation()
        {
            /* This method is publicly available to all, but all derived classes must implement it */
        }
    }

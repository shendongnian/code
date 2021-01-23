    public abstract class InventoryManagerUpdatedDelegateObject : MarshalByRefObject
    {
    
        public void InventoryManagerUpdatedCallback( object sender, InventoryChangeArgs e )
        {
              InventoryManagerUpdatedCallbackCore (sender, e);
        }
    
        protected abstract InventoryManagerUpdatedCallbackCore( object sender, InventoryChangeArgs e );
    
        public override object InitializeLifetimeService()
        {
             return null;
        }
    }

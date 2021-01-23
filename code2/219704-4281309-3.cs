    public class FL
    {
        private BL _myBL;
    
        /// <summary>Constructor</summary>
        public FL ()
        {
            _myBL = new BL(this);
        }
        
        /// <summary>Handles user event</summary>
        public void handleEvent()
        {
            // Call BL to do something
    
            _myBL.foo();
        }
        public void UpdateView(object myBusinessObject)
        {
            // Update your view
        }
    
        public void ShowMessage(string msg)
        {
            // Display message to user
        }
    }

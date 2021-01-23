    public class Demo
    {
        public event EventHandler StateChanged;
    
        protected virtual void OnStateChanged(EventArgs e)
        {        
            StateChanged(this, e); // Exception is thrown here 
                                   // if no event handlers have been attached
                                   // to StateChanged event
        }
    }

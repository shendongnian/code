    abstract class CustomControl : UserControl 
    {
        protected abstract int DoStuff();
    }
    
    class BaseDetailControl : CustomControl
    {
        protected override int DoStuff()
        {
            throw new InvalidOperationException("This method must be overriden.");
        }
    }
    
    class DetailControl : BaseDetailControl
    {
        protected override int DoStuff()
        { 
            // do stuff
            return result;
        }
    }

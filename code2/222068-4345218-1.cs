    public class MyPlugin : IPlugin
    {
        public event EventHandler<ErrorEventArgs> Error;
        public void Initialise()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                OnError(new ErrorEventArgs(e));
            }
        }
        protected void OnError(ErrorEventArgs e)
        {
            var ev = Error;
            if (ev != null)
                ev(this, e);
        }
    }

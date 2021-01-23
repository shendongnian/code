    public abstract class Application
    {
        protected abstract void OnBeforeInit();
        protected abstract void OnAfterInit();
        protected void Run(string[] args)
        {
            OnBeforeInit();
           
            // Do initialization
            OnAfterInit(); 
            ...
        }

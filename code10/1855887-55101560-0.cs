    public class BaseClass 
    {
        protected FileSystemWatcher watcher = new FileSystemWatcher();
    
        public BaseClass()
        {
           ...
            watcher.Changed += OnChanged;
        }
    
        protected virtual void OnChanged(object source, FileSystemEventArgs e)
        {
          //do stuff
        }
    
    }
    public class DerivedClass : BaseClass
    {
           protected override void OnChanged(object source, FileSystemEventArgs e)
           {
                //// your custom handling in the derived class.
           }
    }

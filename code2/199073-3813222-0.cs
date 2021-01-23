    public class A
    {
        public event FileSystemEventHandler FileSystemEvent;
        A()
        {
            this.fsw = new FileSystemWatcher();
            this.fsw.OnFileSystemEvent += (sender, e) => 
                { if(this.FileSystemEvent != null) 
                     this.FileSystemEvent(this,e); };
        }
    }
    public class B
    {
        public event FileSystemEventHandler FileSystemEvent;
        B()
        {
            this.RegisterAClasses();
            foreach( A item in this.AClasses )
                 item.FileSystemEvent += (sender, e) =>
                     { if(this.FileSystemEvent != null) 
                          this.FileSystemEvent(sender, e) };
        }
    }
    public class C
    {
        C()
        {
            this.RegisterBClass();
            this.BClass.FileSystemEvent += (sender, e) => 
                 { /* update gui... */ };
        }
    }

    public class MyDerivedClass : Inode {
    
        // New, more specific version:
        public ClassDerivedOptions Options { get; set; }
    
        // Explicit implementation of old, less specific version:
        ClassOptions Inode.Options
        {
            get { return Options; }
        }
    }

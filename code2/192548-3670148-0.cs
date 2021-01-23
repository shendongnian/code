    public class MyDerivedClass : Inode {
    
        // New, more specific version:
        public ClassDerivedOptions Options { get; set; }
    
        // Explicit implementation of old, less specific version:
        ClassOptions Inode.Options
        {
            get { return Options; }
            set
            {
                var options = value as ClassDerivedOptions;
                if (options == null)
                {
                    throw new ArgumentException("Must be a ClassDerivedOptions.");
                }
    
                Options = options;
            }
        }
    }

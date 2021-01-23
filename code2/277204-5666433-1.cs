    public sealed class DirectoryProvider
    {
        public DirectoryProvider(IEnumerable<string> directories)
        {
            // The validated directories.
            IList<string> validatedDirectories = new List<string>();
            // Validate the directories.
            foreach (string directory in directories)
            {
                // Reconcile full path here.
                string path = ...;
                // If the directory doesn't exist, create it.
                Directory.CreateDirectory(path);
                // Add to the list.
                validatedDirectories.Add(path);
            }
        }
        private readonly IEnumerable<string> _directories;
        public IEnumerable<string> GetPaths()
        {
             // Just return the directories.
             return _directories;
        }
    }

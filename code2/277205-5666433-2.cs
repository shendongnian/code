    public sealed DirectoryProcessor
    {
        public DirectoryProcessor(IDirectoryProvider directoryProvider)
        {
            // Store the provider.
            _directoryProvider = directoryProvider;
        }
        private readonly IDirectoryProvider _directoryProvider;
        public void DoWork()
        {
            // Cycle through the directories from the provider and
            // process.
            foreach (string path in _directoryProvider.GetPaths())
            {
                // Process the path
                ...
            }
        }
    }

    public interface IDirectoryProvider
    {
        // Gets the full paths to the directories being worked on.
        IEnumerable<string> GetPaths();
    }

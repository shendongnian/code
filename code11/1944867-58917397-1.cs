    public interface IDialogService
    {
        void BrowseForDestinationPath(string initialPath);
        
        event PathSelectedEvent PathSelected;
    }
    public delegate void PathSelectedEvent(string destinationPath);  

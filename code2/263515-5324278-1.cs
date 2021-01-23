    public interface IUserInterface
    {
        string AskUserWhereToSaveFile(
            string title, 
            FileType defaultFileType, 
            string defaultFileName = null, 
            params FileType[] otherOptions
        );
        string AskUserToSelectFileToLoad(
           string title, 
           FileType defaultFileType, 
           params FileType[] fileTypes
        );
        void ShowError(string title, string details);
        bool AskUserIfTheyWantToRetryAfter(string errorMessage);
    }

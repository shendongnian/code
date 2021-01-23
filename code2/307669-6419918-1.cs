    public class OperationProgress
    {
        public event EventHandler<FileOperationEventArgs> FileCopied;
        public event EventHandler<DatabaseUpdateEventArgs> DatabaseUpdated;
        public void OnFileCopied(FileOperationEventArgs a)
        {
            if(FileCopied != null)
                FileCopied(this, a);
        }
        public void OnDatabaseUpdated(DatabaseUpdateEventArgs a)
        {
            if (DatabaseUpdated != null)
                DatabaseUpdated(this, a);
        }
    }

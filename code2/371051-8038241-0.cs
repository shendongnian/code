    interface ICommandPattern {
        void Execute();
        void Undo();
    }
    class SaveConfigurationPattern : ICommandPattern {
        string _backupFileName;
        public void Execute()
        {
            // serialize your original and save to the backup file name
            // make changes and save to your config file
        }
        public void Undo()
        {
            // copy your backup file over the configuration file
        }
    }

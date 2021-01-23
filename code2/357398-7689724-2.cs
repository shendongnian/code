    //to use the below class, your Validate method would change to
    public bool Validate()
    {
        return _settingsView.IsValid;
    }
    internal class SettingsView
    {
        private const string DirectoryErrorMessage = "Directory does not exist";
        private string _inPath;
        private string _inPathError;
        private bool _inPathValid;
        private string _outPath;
        private string _outPathError;
        private bool _outPathValid;
        private string _processedPath;
        private string _processedPathError;
        private bool _processedPathValid;
        public string InPath
        {
            get
            {
                return _inPath;
            }
            set
            {
                _inPath = value;
                _inPathValid = Directory.Exists(_inPath);
                _inPathError = _inPathValid ? string.Empty : DirectoryErrorMessage;
            }
        }
        public string InPathError
        {
            get
            {
                return _inPathError ?? string.Empty;
            }
        }
        // Write similar code for Out and Processed paths
        public bool IsValid
        {
            get
            {
                return _inPathValid && _outPathValid && _processedPathValid;
            }
        }
    }

    class MySpecialLoggingConfiguration : XmlLoggingConfiguration
    {
        private string[] _fileNames;
    
        public MySpecialLoggingConfiguration(string[] fileNames)
        {
            _fileNames = fileNames;
            // Your special concat-logic in memory
        }
    
        public override LoggingConfiguration Reload()
        {
            return new MySpecialLoggingConfiguration(_fileNames);
        }
    
        public override IEnumerable<string> FileNamesToWatch => _fileNames;
    }

    class ProcessingResult
    {
        public ProcessingResult(IEnumerable<Foo> processedFiles, IEnumerable<Foo> failures)
        {
            this.ProcessedFiles = processedFiles;
            this.Failures = failures ;
        }
        public IEnumerable<Foo> ProcessedFiles { get; private set; }
        public IEnumerable<Foo> Failures { get; private set; }
    }

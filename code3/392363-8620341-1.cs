        private List<string> SplitFileIntoChunks(string baseFile)
        {
            // Split the file into chunks, and return a list of the filenames.
        }
        private void AnalyseChunk(string filename)
        {
            // Analyses the file and performs replacements, 
            // perhaps writing to the same filename with a different
            // file extension
        }
        private void CreateOutputFileFromChunks(string outputFile, List<string> splitFileNames)
        {
            // Combines the rewritten chunks created by AnalyseChunk back into
            // one large file, outputFile.
        }
        public void AnalyseFile(string inputFile, string outputFile)
        {
            List<string> splitFileNames = SplitFileIntoChunks(inputFile);
            var tasks = new List<Task>();
            foreach (string chunkName in splitFileNames)
            {
                var task = Task.Factory.StartNew(() => AnalyseChunk(chunkName));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            CreateOutputFileFromChunks(outputFile, splitFileNames);
        }

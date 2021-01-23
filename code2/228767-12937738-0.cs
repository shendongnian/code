        GetOrderedFileList2(new DirectoryInfo(@"C:\Program Files\"));
        public List<string> GetOrderedFileList2(DirectoryInfo dirInfo)
        {
            using (new StopWatchPrinter())
            {
                List<string> orderedFileList = dirInfo.EnumerateFiles("*.dll", SearchOption.AllDirectories)
                    .OrderBy(f => f.CreationTime)
                    .Select(f => f.Name)
                    .ToList();
                Debug.Print(string.Format("\n\n *** EnumerateFiles() - found: {0} files ***", orderedFileList.Count));
                return orderedFileList;
            }
        }

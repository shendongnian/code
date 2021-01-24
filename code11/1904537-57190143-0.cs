        public static void CopyActiveFiles(List<string> files, string targetLocation, OutfitCell[] activeCells)
        {
            foreach (string file in files)
            {
                CheckFile(file, activeCells);
            }
        }
        private static void CheckFile(string file, OutfitCell[] activeCells)
        {
            // Thread call
            // declare some thread safe collection.
            // var lines = File.ReadLines(file).Skip(<index>).Take(<count>);
            // Use a variant of the above line to grab a section of lines from the file to then ship out to threads.
        }

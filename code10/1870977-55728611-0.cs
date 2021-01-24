        public List<string> GetLinesOfFile(string folderName)
        {
            FileInfo[] files = new DirectoryInfo(folderName).GetFiles("*.nt940");
            List<string> listYouNeed = new List<string>();
            foreach (FileInfo f in files)
            {
                string[] allLines = File.ReadAllLines(f.FullName);
                listYouNeed.Add(allLines[1]); //HERE YOU READ THE SECOND LINE OF THE FILE
            }
            return listYouNeed;
        }

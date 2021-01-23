     static void FileSplitWriter(List<SplitFile> pList, string info) {
        string[] fileContents = File.ReadAllLines(info);
        string directoryPath = Path.GetDirectoryName(info);
        string filenameok = Path.GetFileNameWithoutExtension(info);
        pList.ForEach(delegate(SplitFile per) {
            int startingLine = per.startingLine;
            int endingLine = per.endingLine;
            var query = fileContents.Skip(startingLine - 1).Take(endingLine - (startingLine - 1));
            StreamWriter ffs = new StreamWriter(directoryPath + "\\" + filenameok + "_split" + per.id + ".csv");
            foreach (string line in query) {
                ffs.WriteLine(line);
            }
            ffs.Close();
            ffs.Dispose();
        });
    }

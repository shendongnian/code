    private List<string> ExtractRar(string varRarFileName,
                                    string varDestinationDirectory) {
        List<string> collection;
        using (var archive = new SevenZipArchive(varRarFileName)) {
            collection = archive.Volumes.ToList(); 
            MessageBox.Show(collection.Count.ToString()); // output 10
        }
        MessageBox.Show(collection.Count.ToString()); // output 0
        return collection;
    }

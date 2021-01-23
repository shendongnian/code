    private ReadOnlyCollection<string> ExtractRar(string varRarFileName,
                                                  string varDestinationDirectory) {
        ReadOnlyCollection<string> collection;
        using (var archive = new SevenZipArchive(varRarFileName)) {
            collection = new ReadOnlyCollection<string>(archive.Volumes.ToList()); 
            MessageBox.Show(collection.Count.ToString()); // output 10
        }
        MessageBox.Show(collection.Count.ToString()); // output 0
        return collection;
    }

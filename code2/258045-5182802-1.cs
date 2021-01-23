    public interface IDiffView
    {
        string SourceFolderPath{ get; set; }
        string RemoteFolderPath{ get; set; }
        string GetFolderPath();
        void PopulateSourceDirectory(IEnumerable<ImageDirectory> dirs);
    }

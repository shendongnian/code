    public struct FileItem : IComparable<FileItem>
    {
        public String Id;
        public int SortIndex;
        public uint Offset;
        public uint Length;
        
        public int CompareTo(FileItem other) { return this.SortIndex.CompareTo(other.SortIndex); }
    }
    public static FileItem[] LoadAndSortFileItems(FILE inputFile)
    {
        FileItem[] result = // fill the array
        Array.Sort(result);
    }
    public static void WriteFileItems(FileItem[] items, FILE inputfile, FILE outputFile)
    {
        foreach (FileItem item in items)
        {
            Copy from inputFile[item.Offset .. item.Length] to outputFile.
        }
    }

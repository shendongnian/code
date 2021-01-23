    class FileExtract
    {
        public int FileId { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }
    var fileExtracts = new List<FileExtract>();
    // take first entry as initializer
    var current = new FileExtract 
                  { 
                      FileId = ListBoxEdit1.First().file_id, 
                      Start = 0, 
                      End = ListBoxEdit1.First().end_line
                  };
    int lastEnd = current.End;
    // skip first entry of the list as it was already used as initializer
    foreach (var p in ListBoxEdit1.Skip())
    {
        if (current.FileId != p.file_id)
        {
            current.End = lastEnd;
            fileExtract.Add(current);
            current = new FileExtract { FileId = p.file_id, Start = lastEnd + 1, End = p.end_line };          
        }
        lastEnd = p.end_line;
    }

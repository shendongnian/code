    public class DirectoryEntry
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresss { get; set; }
        public string Email { get; set; }
    }
    
    public class Directory
    {
        List<DirectoryEntry> _entries;
    
        public Directory()
        {
            _entries = new List<DirectoryEntry>();
        }
    
        public List<DirectoryEntry> Entries { get { return _entries; } }
    }

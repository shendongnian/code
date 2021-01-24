    public class MemberUpdate {
        public string Directory { get; set; }
        public Guid Group { get; set; }
        public List<string> Remove { get; set; }
        public List<string> RemoveAfter { get; set; }
        public string ResultFormat { get; set; }
        public string OnBehalfOf { get; set; }
    }

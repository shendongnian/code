    public partial class PARENT
    {
        public string ID_PARENT { get; set; }
        public int? ID_CHILD { get; set; } (one to one)
        public List<CHILD> Childs { get; set; } (many to one)
    }

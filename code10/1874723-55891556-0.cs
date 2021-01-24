    public class Region
    {
        public int No { get; set; }
        public string Area { get; set; }
        public List<Branch> Branches { get; set; }
    }
    public class Branch
    {
        public int No { get; set; }
        public string Area { get; set; }
        public bool IsValid { get; set; }
    }

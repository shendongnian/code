    public class CostCode {
        public string Description { get; set; }
    }
    public class CostCodes : List<CostCode> {
        public CostCodes()
            : base() {
            Add(new CostCode {Description = "DOM0010 Fall Arr"});
            Add(new CostCode {Description = "DOM0020 Acoustics"});
        }
    }
    // In another class...
    public static void Main(string[] argStrings) {
        CostCodes s = new CostCodes();
        var hasDescription = s.Find(cc => cc.Description != null);
    }

    public static class DeclarationType
    {
    	public static Dictionary<string, int> Orders = new Dictionary<string, int>()
    	{
    		{"EXA", 1},
    		{"EXD", 2},
    		{"EXY", 3},
    		{"EXZ", 4},
    		{"COA", 4},
    		{"COD", 5},
    		{"COY", 6},
    		{"COZ", 7},
    		{"EXB", 8},
    		{"EXC", 9},
    		{"EXE", 10},
    		{"EXF", 11},
    		{"COB", 12},
    		{"COC", 13},
    		{"COE", 14},
    		{"COF", 15},
    		{"EXJ", 16},
    		{"EXK", 17},
    		{"COJ", 18},
    		{"COK", 19}
    	};
    }
    
    public class DeclarationTypeViewObject
    {
        public string Code {get; set;}
        public bool IsBold {get; set;}
        public int Order {get { return !string.IsNullOrEmpty(this.Code) && DeclarationType.ContainsKey(this.Code) ?  DeclarationType.Orders[this.Code] : 100; }}
    }

    public class a
    {
    	public string UserName { get; set; }
    	public string Value { get; set; }
    }
    
    List<a> list = new List<a>
    {
    	new a { UserName = "Perry", Value = "A" },
    	new a { UserName = "Ferb", Value = "B" },
    	new a { UserName = "Phineas", Value = "C" }
    };
    
    List<a> newList = new List<a>
    {
    	new a { UserName = "Phineas", Value = "X" },
    	new a { UserName = "Ferb", Value = "Y" },
    	new a { UserName = "Candace", Value = "Z" }
    };

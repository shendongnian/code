    void Main()
    {
    	var list = new List<ObjectRandom>()
    	{ 
    		new ObjectRandom(){ id = 1, value = "a"},
    		new ObjectRandom(){ id = 2, value = "b"},
    		new ObjectRandom(){ id = 3, value = "c"},
    		new ObjectRandom(){ id = 1, value = "d"},
    		new ObjectRandom(){ id = 2, value = "e"},
    		new ObjectRandom(){ id = 3, value = "f"},
    	};
    	var rnd = new Random();
    	var q = from a in list.GroupBy (l => l.id)
    			let col = a.ToList()
    			select col[rnd.Next(0, col.Count)];
    }
    
    public class ObjectRandom 
    {
    	public int id { get; set; }
    	public string value { get; set;}
    }

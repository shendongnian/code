    void Main()
    {
    	
    	var t = new Test();
    	t.Items.Count.Dump(); //Gives 1
    	AddReferenceToCollection(t, "Items", "testItem");
    	t.Items.Count.Dump(); //Gives 2
    }
    public class Test
    {
    	public IList<string> Items { get; set; }
    	
    	public Test()
    	{
    		Items = new List<string>();
    		Items.Add("ITem");
    	}
    }

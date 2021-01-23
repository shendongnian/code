    public class Column
    {
    	public int Id { get; private set; }
    	public string Name { get; private set; }
    	public Column MainColumn { get; private set; }
    }
    
    void Main()
    {
    	Dictionary<Column, string> dictionary = new Dictionary<Column, string>();
    	dictionary.Add(new Column(), "");
    	dictionary.Add(new Column(), "");
    	dictionary.ContainsKey(dictionary.Keys.ToList()[1]).Dump();
    }

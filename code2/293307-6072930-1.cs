    public class NameValue
    {
    	public NameValue(string name, object value)
    	{
    		Name = name;
    		Value = value;
    	}
    	public string Name { get; set; }
    	public object Value { get; set; }
    }
    
    private void DoSomething(params NameValue[] args)
    {
    	foreach (var nameValue in args)
    	{
    		//sp.AddParameter(nameValue.Name, nameValue.Value);
    	}
    }
    
    private void GenerateTable(Table table)
    {
    	DoSomething(new NameValue("name", "Jonas"), new NameValue("Age", 99));
    }

    	var ST1 = myTableData.ToList();
    	var ST2 = myTableData.ToList();
    
    	var STDiff = from one in ST1 
    				 join two in ST2 
    				 on one.name equals two.name
    				 where one.modifiers.Contains("global")
    			select new
    			{
    				mOneName = one.name,
    				seqEqual = CompareParamsAndGetMatchingIndex(one.parameters, two.parameters),
    				mOneParm = one.parameters,
    				mTwoParm = two.parameters
    			};
    
    private int CompareParamsAndGetMatchingIndex(Parameter[] items1, Parameter[] items2) 
    {
    	if (items1.Length > items2.Length)
    	{
    		return items2.Select((Parameter p, int i) => p.Equals(items1[i]) ? 1 : 0).Sum();
    	}
    	else 
    	{
    		return items1.Select((Parameter p, int i) => p.Equals(items2[i]) ? 1 : 0).Sum();
    	}	
    }
    
    public class SymbolTableRoot
    {
    	public Symboltable SymbolTable { get; set; }
    }
    
    public class Symboltable
    {
    	public Method[] methods { get; set; }
    }
    
    public class Method
    {
    	public Annotation[] annotations { get; set; }
    	public Location location { get; set; }
    	public string[] modifiers { get; set; }
    	public string name { get; set; }
    	public Parameter[] parameters { get; set; }
    	public object[] references { get; set; }
    	public string returnType { get; set; }
    	public object type { get; set; }
    }
    
    public class Location
    {
    	public int column { get; set; }
    	public int line { get; set; }
    }
    
    public class Annotation
    {
    	public string name { get; set; }
    }
    
    public class Parameter : IEquatable<Parameter>
    {
    	public string name { get; set; }
    	public string type { get; set; }
    
    	public bool Equals(Parameter other)
    	{
    		return other?.name == name && other?.type == type;
    	}
    }

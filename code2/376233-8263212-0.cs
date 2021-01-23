    public interface IValue<T>
    {
    	T Value { get; }
    }
    
    public abstract class DataField
    {
    	public DataField(string name, object value)
    	{
    		Name = name;
    		Value = value;
    	}
    	public string Name { get; private set; }
    	public object Value { get; private set; }
    }
    
    public class StringDataField : DataField, IValue<string>
    {
    	public StringDataField(string name, string value)
    		: base(name, value)
    	{
    	}
    
    	string IValue<string>.Value
    	{
    		get { return (string)Value; }
    	}
    }
    
    public class IntDataField : DataField, IValue<int>
    {
    	public IntDataField(string name, int value)
    		: base(name, value)
    	{
    	}
    
    	int IValue<int>.Value
    	{
    		get { return (int)Value; }
    	}
    }

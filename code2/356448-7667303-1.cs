    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    
    public class ValueWithId
    {
    	public string ShortName;
    	public string ActualValue;
    	
    	public ValueWithId(string shortName, string actualValue)
    	{
    		ShortName = shortName;
    		ActualValue = actualValue;
    	}
    	
    	public override string ToString()
    	{
    		return ShortName + "->" + ActualValue;
    	}
    }
    
    public class CollectionOfValuesWithId
    {
    	private IList<ValueWithId> Values = new List<ValueWithId>();
    	
    	public void AddValue(ValueWithId val)
    	{
    		Values.Add(val);
    	}
    	
    	public ValueWithId GetValueFromId(string id)
    	{
    		foreach (var value in Values)
    			if (value.ShortName == id)
    				return value;
    		return null;
    	}
    }
    
    [Serializable]
    public class SomeClassThatUsesValueWithId : ISerializable
    {
    	public ValueWithId Val;
    	
    	public SomeClassThatUsesValueWithId(ValueWithId val)
    	{
    		Val = val;
    	}
    	
    	public SomeClassThatUsesValueWithId(SerializationInfo info, StreamingContext ctxt)
    	{
    		string valId = (string)info.GetString("Val");
    		CollectionOfValuesWithId col = ctxt.Context as CollectionOfValuesWithId;
    		if (col != null)
    			Val = col.GetValueFromId(valId);
    	}
    	
    	public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    	{
    		//Store Val.ShortName instead of Val because we don't want to store the entire object
    		info.AddValue("Val", Val.ShortName);
    	}
    	
    	public override string ToString()
    	{
    		return "Content="+Val;
    	}
    }
    
    class MainClass
    {
    	public static void Main(string[] args)
    	{
    		CollectionOfValuesWithId col = new CollectionOfValuesWithId();
    		col.AddValue(new ValueWithId("foo", "bar"));
    		
    		SomeClassThatUsesValueWithId sc = new SomeClassThatUsesValueWithId(col.GetValueFromId("foo"));
    		
    		BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.File, col));
    		
    		using (var stream = new FileStream("foo", FileMode.Create))
    		{
    			bf.Serialize(stream, sc);
    		}
    		
    		col.GetValueFromId("foo").ActualValue = "new value";
    		
    		using (var stream2 = new FileStream("foo", FileMode.Open))
    		{
    			Console.WriteLine(bf.Deserialize(stream2));
    		}
    	}
    }

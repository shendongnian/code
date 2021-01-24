    using System;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{\"Results\":{\"output1\":{\"type\":\"table\",\"value\":{\"ColumnNames\":[\"Purchased Bike\",\"Scored Labels\"],\"ColumnTypes\":[\"String\",\"Double\"],\"Values\":[[\"value\",\"0.55503808930127\"]]}}}}";
    		var parsed = JsonConvert.DeserializeObject<Rootobject>(json);
    		
    		foreach (var array in parsed.Results.output1.value.Values)
    			foreach (var entry in array)
    				Console.WriteLine(entry);
		
            Console.WriteLine("\r\nItem Value: " + parsed.Results.output1.value.Values[0][1]);
    	}
    }
    
    // Generated classes:
    
    public class Rootobject
    {
    	public Results Results { get; set; }
    }
    
    public class Results
    {
    	public Output1 output1 { get; set; }
    }
    
    public class Output1
    {
    	public string type { get; set; }
    	public Value value { get; set; }
    }
    
    public class Value
    {
    	public string[] ColumnNames { get; set; }
    	public string[] ColumnTypes { get; set; }
    	public string[][] Values { get; set; }
    }

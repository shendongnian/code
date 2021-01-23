    public void OutputEnumValues<T>() where T : HorizontalAlignment
    {
    	foreach (string name in Enum.GetNames(typeof(T)))
    	{
    		Console.WriteLine(name);
    	}
    }

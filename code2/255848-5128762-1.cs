    private Delegate GetTypeSpecificSerializationMethod()
    {
    	if (typeof(T) == typeof(double))
    	{
    		MethodInfo method = this.GetType().GetMethod("SerializeDouble", BindingFlags.Static | BindingFlags.NonPublic);
    		return Delegate.CreateDelegate(typeof(Action<BinaryWriter, int, T[]>), method);
    	}
    	else if (typeof(T) == typeof(ushort))
    	{
    	...
	
	
    private static void SerializeDouble(BinaryWriter writer, int size, double[] data)
    {
    	for (int i = 0; i < size; i++)
    	{
    		writer.Write(data[i]);
    	}
    }

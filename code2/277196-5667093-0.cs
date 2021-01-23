    /// <summary>
    /// Returns a delegate that points at the static type specific serialization method
    /// </summary>
    /// <returns></returns>
    private Delegate GetTypeSpecificDeserializationMethod()
    {
    	if (typeof(T) == typeof(double))
    	{
    		MethodInfo method = this.GetType().GetMethod("DeserializeDouble", BindingFlags.Static | BindingFlags.NonPublic);
    		return Delegate.CreateDelegate(typeof(Action<BinaryReader, int, T[]>), method);
    	}
    	else if (typeof(T) == typeof(ushort))
    	{
    		MethodInfo method = this.GetType().GetMethod("DeserializeUshort", BindingFlags.Static | BindingFlags.NonPublic);
    		return Delegate.CreateDelegate(typeof(Action<BinaryReader, int, T[]>), method);
    	}
    	else if (typeof(T) == typeof(DateTime))
    	{
    		MethodInfo method = this.GetType().GetMethod("DeserializeDateTime", BindingFlags.Static | BindingFlags.NonPublic);
    		return Delegate.CreateDelegate(typeof(Action<BinaryReader, int, T[]>), method);
    	}
    	else if (typeof(T) == typeof(bool))
    	{
    		MethodInfo method = this.GetType().GetMethod("DeserializeBool", BindingFlags.Static | BindingFlags.NonPublic);
    		return Delegate.CreateDelegate(typeof(Action<BinaryReader, int, T[]>), method);
    	}
    
    	throw new NotImplementedException("No deserialization method has been setup for type " + typeof(T).FullName);
    }
    
    /// <summary>
    /// Serialize double[] to BinaryWriter
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="size"></param>
    /// <param name="data"></param>
    private static void SerializeDouble(BinaryWriter writer, int size, double[] data)
    {
    	for (int i = 0; i < size; i++)
    	{
    		writer.Write(data[i]);
    	}
    }

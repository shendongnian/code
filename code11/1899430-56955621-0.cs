GTMType ParseGTMTypeFromAnotherSystem(string gtmType)
{
	var type = typeof(GTMType);
	foreach (var value in Enum.GetValues(type))
	{
		var fieldInfo = type.GetField(Enum.GetName(type, value));
		DisplayAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
		if (attributes.Length != 1)
        {
            throw new Exception("Enum definition is wrong.");
        }
    
	    var displayName = attributes[0].Name;
        if (gtmType == displayName)
        {
            return value as GTMType;
        }
	}
    throw new Exception("Unable to parse.");
}
You may want to handle the exception cases differently, e.g. iterate over all DisplayAttributes in case there's more than one and ignore fields that have none, or in case of a failed parse return a default value - depends on your use case.

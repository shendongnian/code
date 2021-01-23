    public static void DisplayObjectInterface(object source, Type InterfaceName)
    {
        // Get the interface we are interested in
        var Interface = source.GetType().GetInterface(InterfaceName.Name);
        if (Interface != null)
        {
            // Get the properties from the interface, instead of our source.
            var propertyList = Interface.GetProperties();
            foreach (var property in propertyList)
                Debug.Log(InterfaceName.Name + " : " + property.Name + "Value " + property.GetValue(source, null));
        }
        else
            Debug.Log("Warning: Interface does not belong to object.");
    }

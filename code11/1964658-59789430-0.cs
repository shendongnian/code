    dynamic evtPc1 = JsonConvert.DeserializeObject(json);
    PropertyInfo[] properties = evtPc1.GetType().GetProperties();
    for (int i = 0; i < properties.Length; i++)
    {
        var prop = properties[i];
        if (prop.GetIndexParameters().Length == 0)
            Console.WriteLine("{0} ({1}): {2}", prop.Name,
                prop.PropertyType.Name,
                prop.GetValue(evtPc1));
        else
            Console.WriteLine("{0} ({1}): <Indexed>", prop.Name,
                prop.PropertyType.Name);
    }

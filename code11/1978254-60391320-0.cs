    public static void PrintProperties(object obj, int indent = 1)
    {
        if (obj == null)
            return;
        string indentString = new string(' ', indent);
        Type objType    = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            object propValue;
            if (objType == typeof(string))
                return; // Handled at a higher level, so nothing to do here.
            if (property.PropertyType.IsArray)
                propValue = (Array)property.GetValue(obj);
            else
                propValue = property.GetValue(obj, null);
            var elems = propValue as IList;
            if (elems != null)
            {
                Console.WriteLine("{0}{1}: IList of {2}", indentString, property.Name, propValue.GetType().Name);
                
                for (int i = 0; i < elems.Count; ++i)
                {
                    Console.WriteLine("{0}{1}[{2}] == {3}", indentString, property.Name, i, elems[i]);
                    if (objType != typeof(string))
                        PrintProperties(elems[i], indent + 3);
                }
            }
            else
            {
                if (property.PropertyType.Assembly == objType.Assembly)
                {
                    Console.WriteLine("{0}{1}:", indentString, property.Name);
                    PrintProperties(propValue, indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }
        }
    }

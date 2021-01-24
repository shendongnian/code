    foreach (var prop in propDict) {
        var qryProp = personList.Select(x => prop.Value.GetValue(x));
        Array tempArray = null;
        switch (Type.GetTypeCode(prop.Value.PropertyType)) {
            case TypeCode.String:
                tempArray = qryProp.Cast<string>().ToArray();
            break;
            case TypeCode.Int32:
                tempArray = qryProp.Cast<Int32>().ToArray();
            break;
        }
        Console.WriteLine(tempArray.GetType().Name);//String[]/Int32[]
    }

    var list = new List<DataField>()
    {
        new DataField<int>() {Name = "int", Value = 2},
        new DataField<string>() {Name = "string", Value = "stringValue"},
        new DataField<float>() {Name = "string", Value = 2f},
    };
    var sum = 0.0;
    foreach (var dataField in list)
    {
        if (dataField.GetType().IsGenericType)
        {
            if (dataField.GetType().GetGenericArguments()[0] == typeof(int))
            {
                sum += ((DataField<int>) dataField).Value;
            }
            else if (dataField.GetType().GetGenericArguments()[0] == typeof(float))
            {
                sum += ((DataField<float>)dataField).Value;
            }
            // ..
        }
    }

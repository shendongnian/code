    private void DoProperties(object obj)
    {
        Type objectType = obj.GetType();
        foreach (var property in objectType.GetProperties())
        {
            string name = property.Name;
            string value = property.GetValue(obj, null).ToString();
            //Do some other stuff...
        }
    }

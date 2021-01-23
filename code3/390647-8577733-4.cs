    private void Form1_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        PropertyInfo info = GetProperty(sb, "Capacity");
        //To get the value of the property, call GetValue on the PropertyInfo with the object and null parameters:
        info.GetValue(sb, null);
        //To set the value of the property, call SetValue on the PropertyInfo with the object, value, and null parameters:
        info.SetValue(sb, 20, null);
    }
    private PropertyInfo GetProperty(object obj, string property)
    {
        PropertyInfo info = obj.GetType().GetProperty(property);
        if (info != null && info.CanRead && info.CanWrite)
            return info;
        return null;
    }

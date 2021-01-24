    public void CheckObjectFormatValues(object o)
    {
        FieldInfo[] fields = o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (System.Reflection.FieldInfo prp in fields)
        {
            if (prp.FieldType.BaseType != typeof(ValueType))
            {
                if(ShouldRecurse(prp.FieldType))
                     CheckObjectFormatValues(prp.GetValue(o));               
            }
            else
            {
                var value = prp.GetValue(o).ToString();
                if (value == "-1")
                    throw new Exception("Error");
            }
        }
    }
    private bool ShouldRecurse(Type fieldType)
    {
        // TODO
    }

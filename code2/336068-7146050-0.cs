    public void PrintField()
    {
        Type t = this.GetType();
        FieldInfo[] fi = t.GetFields();
        foreach (FieldInfo field in fi)
        {
            Console.Write("Field: {0}: {1}\n", field.Name, prop.GetValue(this));
        }
    }

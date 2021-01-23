    public TestObject(Data.MyDataTable table) : this(table[0])
    {
    }
    public TestObject(Data.MyDataRow row) : this(row.Name, row.Value)
    {
    }
    public TestObject(String name, String value)
    {
     // Some checks if the strings are valid
     _name = name;
     _value = value;
    }

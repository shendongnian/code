    public static class DataTypes
    {
        static ReadOnlyCollection<Type> AvailableTypes;
        static DataTypes()
        {
            List<Type> Types = new List<Type>();
            Types.Add(typeof(MyTypeA));
            Types.Add(typeof(MyTypeB));
            AvailableTypes = new ReadOnlyCollection<MyDataType>(Type);
        }
    }

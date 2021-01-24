    class MyClass
    {
        private static IEnumerable<PropertyInfo> arrays = 
            typeof(MyClass).GetProperties().Where((x) => x.PropertyType.IsArray);
        public object this[int index, string name]
        {
            get => ((Array)arrays.First((x) => x.Name == name).GetValue(this)).GetValue(index);
            set => ((Array)arrays.First((x) => x.Name == name).GetValue(this)).SetValue(value, index);
        }
    }

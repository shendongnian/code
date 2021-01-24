    class MyClass
    {
        private static IEnumerable<FieldInfo> arrays = typeof(MyClass).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
            Where((x) => x.FieldType.IsArray);
        public object this[int index, string name]
        {
            get => ((Array)arrays.First((x) => x.Name == name).GetValue(this)).GetValue(index);
            set => ((Array)arrays.First((x) => x.Name == name).GetValue(this)).SetValue(value, index);
        }
    }

    public struct MyStruct
    {
        public const string A = "A";
        public const string B = "B";
        public const string C = "C";
        public static IEnumerable GetValues(Type type)
        {
            List<String> retVals = new List<string>();
            FieldInfo[] fi = type.GetFields();
            foreach (FieldInfo info in fi)
            {
                retVals.Add(info.Name);
            }
            return retVals;
        }
    }

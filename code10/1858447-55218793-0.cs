            var data = new Dictionary<string, TestData>
            {
                { "A1", new TestData { Name = "N1", Section = "S1" } },
                { "A2", new TestData { Name = "N2", Section = "S2" } }
            };
            var strArray = new string[2] { "Name1", "Section" };
            foreach (KeyValuePair<string, TestData> entry in data)
            {
                foreach (string value in strArray)
                {
                    var x = entry.Value.GetValueByName(value);
                }
            }
    public static class GetValueByNameExtension
    {
        private static object thisLock = new object();
        private static Dictionary<string, PropertyInfo[]> table = new Dictionary<string, PropertyInfo[]>();
        public static object GetValueByName(this object obj, string propertyName)
        {
            var t = obj.GetType();
            lock(thisLock)
            {
                if (!table.ContainsKey(t.FullName))
                {
                    table.Add(t.FullName, t.GetProperties());
                }
            }
            return table[t.FullName].First((x) => x.Name == propertyName).GetValue(obj);
        }
    }

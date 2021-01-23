    internal class FildMap
    {
        public string ExactTargetFild { get; set; }
        public string DbFild { get; set; }
        public Type Type { get; set; }
        public  object GetValue(object value)
        {
            switch(Type.Name)
            {
                case "System.String":
                    // [Code]
                    break;
                case "System.DateTime":
                    // [Code]
                    break;
                case "System.Boolean":
                    // [Code]
                    break;
            }
            return null;
        }
    }
    internal static class FildMapProcessor
    {
        private static readonly List<FildMap> Map = new List<FildMap>();
        static FildMapProcessor()
        {
            if (Map.Count == 0)
            {
                Map.Add(new FildMap { ExactTargetFild = "Address 1", DbFild = "Address1", Type = typeof(string) });
                Map.Add(new FildMap { ExactTargetFild = "Date of birth", DbFild = "DateOfBirth", Type = typeof(DateTime) });
                Map.Add(new FildMap { ExactTargetFild = "Wine Beer", DbFild = "pref_WineBeerSpirits", Type = typeof(bool) });
            }
        }
        public static Attribute[] CreateAttributes(this DataRow row)
        {
            var attributes = new List<Attribute>();
            foreach (var item in Map)
            {
                foreach (var item in Map)
                {
                    var value = item.GetValue(row[item.DbFild]);
                    if(value != null)
                        attributes.Add(new Attribute { Name = item.ExactTargetFild, Value = value });
                }
            }           
            return attributes.ToArray();
        }
    }

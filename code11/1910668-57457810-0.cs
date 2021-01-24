        struct SomeStruct
        {
            private static PropertyInfo[] properties = typeof(SomeStruct).GetProperties();
            private static Random random = new Random();
            public string type1 { get; set; }
            public string type2 { get; set; }
            public string type3 { get; set; }
            public string type4 { get; set; }
            public string TakeOneRandom()
            {
                int index = random.Next(properties.Length);
                return properties[index].GetValue(this)?.ToString();
            }
        }

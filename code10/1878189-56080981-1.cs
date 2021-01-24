        static void Sample()
        {
            List<string> properties = new List<string>();
            properties.Add("FirstName");
            properties.Add("LastName");
            var exp = generateSelectExpression<User>(properties);
        }
        class User
        {
            public string FirstName;
            public string LastName;
        }
        private static Expression<Func<T, object>> generateSelectExpression<T>(List<string> propertiesToSelect)
        {
            Expression<Func<T, object>> exp = (x) => GetDynamicFromDictionary(GetProperties(x), propertiesToSelect);
            return exp;
        }
        private static dynamic GetDynamicFromDictionary(Dictionary<string,object> dict, List<string> propertiesToSelect)
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;
            foreach (var kvp in dict)
            {
                if (propertiesToSelect.Contains(kvp.Key))
                {
                    eoColl.Add(kvp);
                }
            }
            dynamic eoDynamic = eo;
            return eoDynamic;
        }
        private static Dictionary<string, object> GetProperties(object obj)
        {
            var props = new Dictionary<string, object>();
            if (obj == null)
                return props;
            var type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                var val = prop.GetValue(obj, new object[] { });
                props.Add(prop.Name, val);
            }
            return props;
        }

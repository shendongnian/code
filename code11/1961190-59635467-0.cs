        private static string PrintObject(object obj)
        {
            var type = obj.GetType();
            if (type.IsPrimitive || type == typeof(Decimal) || type == typeof(String))
                return "\"" + obj.ToString() + "\"";
            var props = type.GetProperties();
            string ret = "";
            for (var i = 0; i < props.Length; i++)
            {
                var val = props[i].GetValue(obj);
                ret += "\"" + props[i].Name + "\":" + PrintObject(val);
                if (i != props.Length - 1)
                    ret += ",";
            }
            return "{" + ret + "}";
        }

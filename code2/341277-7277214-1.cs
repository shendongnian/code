        public static string Convert(object value)
        {
            if (value is string) 
                return value.ToString();
            var data = value as IEnumerable;
            if (data == null)
                return string.Empty; // I think you missed this one
            var e = data.Cast<object>();
            return e.Count() == 0 ?
                    string.Empty :
                    e.Select(o => Convert(o)).Aggregate("", (c, s) => c + s);
        }

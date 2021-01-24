       public static  double GetValue(string input)
        {
            var map = new Dictionary<string, int>()
            {
                 {"a", 10 }, {"b", 20}, {"c", 30}, {"d", 40}
            };
            int result = 0;
            foreach(var i in map)
            {
                int endIndex, outValue;
                string value;
                endIndex = input.ToLower().IndexOf(i.Key);
                value = input.Substring(endIndex -1,  1);
                int.TryParse(value, out outValue);
                result += (i.Value * outValue);
            }
            return result;
        }

      class Program
      {
        static void Main()
        {
            string input = "<parameter1(value1)>< parameter2(value2)>";
            string[] Items = input.Replace("<", "").Split('>');
            List<string> parameters = new List<string>();
            List<string> values = new List<string>();
            foreach (var item in Items)
            {
                if (item != "")
                {
                    KeyValuePair<string, string> kvp = GetInnerItem(item);
                    parameters.Add(kvp.Key);
                    values.Add(kvp.Value);
                }
            }
            // if you really wanted your results in arrays
            //
            string[] parametersArray = parameters.ToArray();
            string[] valuesArray = values.ToArray();
        }
        public static KeyValuePair<string, string> GetInnerItem(string item)
        {
            //expects parameter1(value1)
            string[] s = item.Replace(")", "").Split('(');
            return new KeyValuePair<string, string>(s[0].Trim(), s[1].Trim());
        }
    }

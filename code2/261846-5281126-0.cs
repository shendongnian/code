    class Template
    {
        // map identifiers to templates
        static Dictionary<string, string> templates = new Dictionary<string, string>
        {
            { "type1", "isss" },
            { "type2", "iisss" },
        };
        static bool ParseItem(string input, char type, out object output)
        {
            output = null;
            switch (type)
            {
                case 'i':
                    int i;
                    bool valid = int.TryParse(input, out i);
                    output = i;
                    return valid;
                case 's':
                    output = input;
                    return true;
            }
            return false;
        }
        public static object[] ParseString(string input)
        {
            string[] items = input.Split(',');
            // make sure we have enough items
            if (items.Length < 2)
                return null;
            object[] output = new object[items.Length - 2];
            string identifier = items[1];
            string template;
            // make sure a valid identifier was specified
            if (!templates.TryGetValue(identifier, out template))
                return null;
            // make sure we have the right amount of data
            if (template.Length != output.Length)
                return null;
            // parse each item
            for (int i = 0; i < template.Length; i++)
                if (!ParseItem(items[i + 2], template[i], out output[i]))
                    return null;
            return output;
        }
    }

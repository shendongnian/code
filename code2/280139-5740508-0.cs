           // CSV rules: http://en.wikipedia.org/wiki/Comma-separated_values#Basic_rules
            // From the rules:
            // 1. if the data has quote, escape the quote in the data
            // 2. if the data contains the delimiter (in our case ','), double-quote it
            // 3. if the data contains the new-line, double-quote it.
            if (data.Contains("\""))
            {
                data = data.Replace("\"", "\"\"");
            }
            if (data.Contains(","))
            {
                data = String.Format("\"{0}\"", data);
            }
            if (data.Contains(System.Environment.NewLine))
            {
                data = String.Format("\"{0}\"", data);
            }

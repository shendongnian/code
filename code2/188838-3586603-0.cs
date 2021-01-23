        public static string RemoveDuplicates(string input)
        {
            string output = string.Empty;
            System.Collections.Specialized.StringCollection unique = new System.Collections.Specialized.StringCollection();
            string[] parts = input.Split(':');
            foreach (string part in parts)
            {
                output += ":";
                if (!unique.Contains(part))
                {
                    unique.Add(part);
                    output += part;
                }
            }
            output = output.Substring(1);
            return output;
        }

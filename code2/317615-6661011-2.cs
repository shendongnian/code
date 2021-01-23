        static void Main(string[] args)
        {
            string f = "{field1}-{field}+{field3}Anthing{field4} ";
            List<string> lstPattern = new List<string>();
            foreach (Match m in Regex.Matches(f, "{.*?}"))
            {
                lstPattern.Add(m.Value.Replace("{","").Replace("}",""));
            }
            foreach (var p in lstPattern)
                Console.WriteLine(p);
        }

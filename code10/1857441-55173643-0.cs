        public static List<Int32> ExtractInts(String filePath)
        {
            String input = File.ReadAllText(filePath);
            List<Int32> ints = new List<Int32>();
            Regex r = new Regex(" = (\\d+)");
            MatchCollection mc = r.Matches(input);
            foreach(Match m in mc)
                ints.Add(Int32.Parse(m.Groups[1].Value));
            return ints;
        }

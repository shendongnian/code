    public static IDictionary<string, string> Results { get; set; }
        public static IDictionary<string, string> Results1 { get; set; }
        private static void Main(string[] args)
        {
        StringBuilder strBldr = new StringBuilder();
            string outputFile = @"D:\12.csv"; 
            Results = new Dictionary<string, string>()
            {
                {"N1", "20"},
                {"N2", "0.399992"},
                {"N3", "0.369442"},
                {"N4", "0.369976"}
            };
            Results1 = new Dictionary<string, string>()
            {
                {"N1", "100"},
                {"N2", "99.9805"},
                {"N3", "92.36053"},
                {"N4", "92.49407"}
            };
            IEnumerable<string> results = Results.Zip(Results1,
                (firstList, secondList) => firstList.Key + "," + firstList.Value + "," + secondList.Value);
            foreach (string res1 in results)
            {
                strBldr.AppendLine(res1);
            }
            File.WriteAllText(outputFile, strBldr.ToString());
        }

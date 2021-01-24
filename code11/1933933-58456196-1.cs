    static void add_ints(string root)
        {
            Deedle.Frame<int, string> df = Frame.ReadCsv("data_ints.csv");
            Series<int, int> a = df.GetColumn<int>("A");
            Series<int, int> b = df.GetColumn<int>("B");
            //creates a column with the average of the row (not so useful with int)
            Series<int, int> avgCol = df.Mutate<int, int, string>(avgMutator);
            Series<int, int> c = a + b;
            df.AddColumn("C", c);
            df.AddColumn("D", avgCol);
            df.Print();
        }
        static void add_strings(string root)
        {
            Deedle.Frame<int, string> df = Frame.ReadCsv("data_strings.csv");
            Series<int, string> a = df.GetColumn<string>("L");
            Series<int, string> b = df.GetColumn<string>("R");
            //creates a column of concatenanted values
            Series<int,string> concatCol = df.Mutate<int,string,string>(ConcatMutator);
            //creates a column of concatenated and UPPER values
            Series<int, string> upperCol = df.Mutate<int, string, string>(ToUpperMutator);
            df.AddColumn("C", concatCol);
            df.AddColumn("D", upperCol);
            df.Print();
        }      
        private static string ConcatMutator(string[] inputs) => string.Concat(inputs);
        private static string ToUpperMutator(string[] inputs)
        {
            IEnumerable<string> uppers = inputs.Select(e => e.ToUpper());
            return string.Concat(uppers);
        }
        private static int avgMutator(int[] inputs) => (int)Math.Round(inputs.Average(), 0);

    static void add_strings(string root)
        {
            Deedle.Frame<int, string> df = Frame.ReadCsv("data_strings.csv");
            Series<int, string> a = df.GetColumn<string>("L");
            Series<int, string> b = df.GetColumn<string>("R");
            // Series<int, string> c = a + b;
            // Series<int, string> c = $"{a} and {b}";
            int rowCount = a.ValueCount + b.ValueCount;
            int[] keys = Enumerable.Range(0, rowCount).ToArray();
            Series<int, string> c = new Series<int, string>(keys, a.Values.Concat(b.Values));
            df.AddColumn("C", c);
            df.Print();
        }

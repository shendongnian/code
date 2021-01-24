    static void add_strings(string root)
        {
            Deedle.Frame<int, string> df = Frame.ReadCsv("data_strings.csv");
            Series<int, string> a = df.GetColumn<string>("L");
            Series<int, string> b = df.GetColumn<string>("R");
            RowSeries<int, string> rs = df.Rows;
            SeriesBuilder<int, string> c = new SeriesBuilder<int, string>();
            for (int i = 0; i < rs.KeyCount; i++)
            {
                c.Add(i, a[i] + b[i]);
            }
            df.AddColumn("C", c);
            df.Print();
        }

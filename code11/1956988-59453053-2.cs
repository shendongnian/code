    static void Main(string[] args)
    {
        var datas = new List<Device>
        {
            new Device { ID = 1, PatName = "ABC" },
            new Device { ID = 2, PatName = "DEF" },
            new Device { ID = 3, PatName = "GHO" }
        };
        var MatrixValues = datas
            .SelectMany(x => x.Array)
            .Select((item, index) => new KeyValuePair<double, string>(Convert.ToDouble(index), item)).ToArray();
        var matrixIndexes = MatrixValues.Select(x => x.Key);
        var M = Matrix<double>.Build;
        var C = M.Dense(datas.Count, datas.First().Array.Count(), matrixIndexes.ToArray());
        var TR = C.Transpose();
        string columns = "Device #".PadRight(10, ' ') + "\n" + "Pt.Name".PadRight(10, ' ');
        StringBuilder sb = new StringBuilder(columns);
        for (int i = 0; i < TR.Storage.Enumerate().Count(); i += 2)
        {
            sb = sb.AppendRight(MatrixValues[i].Value, MatrixValues[i + 1].Value);
        }
        Console.WriteLine(sb.ToString());
        Console.ReadLine();
    }

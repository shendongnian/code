    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < 3; i++)
                dt.Columns.Add("col" + i);
            foreach (var line in File.ReadAllLines(@"C:\temp\a.tsv"))
                dt.Rows.Add(line.Split('\t'));
            int c = dt.Rows.Count; //not necessary, just makes for an easy place to put a breakpoint
        }
    }

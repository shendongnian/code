    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");
            for (int i = 0; i < 103; ++i)
            {
                var r = dt.NewRow();
                r[0] = Guid.NewGuid().ToString();
                r[1] = i.ToString();
                dt.Rows.Add(r);
            }
            WriteCsvFile(dt, 25, @"C:\temp\test.txt");
        }
        public static string[] ToStringArray(DataRow row)
        {
            var arr = new string[row.Table.Columns.Count];
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = row[j].ToString();
                if((arr[j]??"").Contains(","))
                    throw new Exception("This will end badly...");
            }
            return arr;
        }
        public static void WriteCsvFile(DataTable table, int maxCount, string fileName)
        {
            if (table.Rows.Count <= maxCount)
                WriteCsvFile(table, maxCount, fileName, 0);
            else
                for (int i = 0; i < (table.Rows.Count / maxCount + 1); ++i)
                {
                    var partFileName = Path.Combine(Path.GetDirectoryName(fileName), string.Format("{0}-part{1}{2}", Path.GetFileNameWithoutExtension(fileName), i+1, Path.GetExtension(fileName)));
                    WriteCsvFile(table, maxCount, partFileName, i * maxCount);
                }
        }
        public static void WriteCsvFile(DataTable table, int maxCount, string fileName, int startIndex)
        {
            using(var fs = File.Create(fileName))
            using(var w = new StreamWriter(fs, Encoding.ASCII))
            {
                for (int i = startIndex; i < Math.Min(table.Rows.Count, startIndex + maxCount); i++)
                    w.WriteLine(String.Join(",", ToStringArray(table.Rows[i])));
                w.Flush();
            }
        }
    }

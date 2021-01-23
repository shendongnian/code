    public static IEnumerable<string> GetSqlBatches(string filename)
    {
        using(StreamReader sr = new StreamReader(filename))
        {
            StringBuilder ReadSoFar = new StringBuilder();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                ReadSoFar.AppendLine(line);
                if (line.Trim() == "GO")
                {
                    yield return ReadSoFar.ToString();
                    ReadSoFar = new StringBuilder();
                }
            }
            sr.Close();
        }
    }

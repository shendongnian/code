    public IEnumerable<IEnumerable<string[]>> ReadFileByLines(string cs, int Buffer = BUFFER)
       {
            OdbcConnection conn = new OdbcConnection(cs);
            OdbcCommand cmd = new OdbcCommand(sql, conn);
            OdbcDataReader reader = cmd.ExecuteReader();
            List<string[]> bufferList = new List<string[]>(Buffer);
            while (reader.Read())
            {
                bufferList.Add(reader["something"]); // or add a custom class here
                if (bufferList.Count == Buffer)
                {
                    yield return bufferList.ToArray();
                    bufferList = new List<string[]>(Buffer);
                }
            }
            yield return bufferList.ToArray();
        }

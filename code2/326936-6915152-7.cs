        bool ExportPartition(string fileName, DataTable table, int batchSize, int batchNum)
        {
            string fn = string.Format("{0}-{1}{2}",                                     
                                      Path.GetFileNameWithoutExtension(fileName),
                                      batchNum,
                                      Path.GetExtension(fileName));
            fn = Path.Combine(Path.GetDirectoryName(fileName), fn);
            using (TextWriter writer = new StreamWriter(fn))
            {
                int start = batchNum * batchSize;
                int end = start + batchSize;
                for (int i = start; i < end; i++)
                {
                    if (i >= table.Rows.Count)
                        break;
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        writer.Write(table.Rows[i][j] + ",");
                    }
                    writer.Write("\r\n");
                }
                return table.Rows.Count <= end;
            }
        }

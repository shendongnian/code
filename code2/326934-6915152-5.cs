    public bool ExportPartition(SaveFileDialog saveFile, DataTable table, int batchSize, int batchNum)
    {
        try 
        {
           string fn = string.Format("{0}-{1}{2}", 
             Path.GetFileNameWithoutExtension(saveFile.FileName),
             batchNum,
             Path.GetExtension(saveFile.FileName));
            
           TextWriter writer = new StreamWriter(fn, ...);
           int start = batchNum * batchSize;
           int end = start + batchSize;
           for (int i = start; i < end; i++)
           {
               if (i >= table.Rows.Count)
                  break;
               for (int j = 0; j < table.Columns.Count; j++)
               {
                   writer.Write(table.Rows[i][j].ToString() + ",");
               }
               writer.Write("\r\n");
           }
           return table.Rows.Count > end;
        }
        finally 
        {
           writer.Flush();
           DisposeObjects(saveFile, writer);
        }
    }

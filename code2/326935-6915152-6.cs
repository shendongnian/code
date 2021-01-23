    void WriteFiles(DataTable table, SaveFileDialog saveFile, int batchSize)
    {
       int batchNum = 0;
       int batchSize = 25000;
       bool done = false;
       while (!done)
       {
           done = ExportPartition(saveFile, table, batchSize, batchNum++);
       }
    }
    

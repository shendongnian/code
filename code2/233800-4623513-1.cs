    private DataTable GetTextToTable(string path)
    {
        try
        {
            DataTable dataTable = new DataTable
            {
                Columns = {
                    {"MyID", typeof(int)},
                    "MyData"
                },
                TableName="MyTable"
            };
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(path))
            {
                String line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new string[] { "\\t" }, StringSplitOptions.RemoveEmptyEntries);
                    dataTable.Rows.Add(words[0], words[1]);
                }
            }
            return dataTable;
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            throw new Exception(e.Message);
        }
    
    }

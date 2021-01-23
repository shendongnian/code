    public int[] ImportData(string path)
    {
         List<int> loadedData = new List<int>();
         loadedData.Clear();
         try
         {
            using (StreamReader readCSV = new StreamReader(path))
            {
                string line;
                string[] row;
                while ((line = readCSV.ReadLine()) != null)
                {
                    row = line.Split(',');
                    foreach(var token in row)
                    {
                        loadedData.Add(Convert.ToInt32(token));
                    }
                }
            }
         }
         catch
         {
            MessageBox.Show("Import Failed. Please check the file is in the same folder as the executable");
         }
         return loadedData.ToArray();
    }

    private int SumOfCSV(string filePath)
    {
            string csvContent = String.Empty;
            int returnValue = 0;
            try
            {
                StreamReader reader = new StreamReader(filePath);
                csvContent = reader.ReadToEnd();
                reader.Close();
                
                foreach(string value in csvContent.Split(';'))
                {
                    returnValue += Convert.ToInt32(value);
                
                }               
                
            }
            catch (Exception)
            {
                Console.WriteLine("Reading " + Path.GetFileName(filePath) + " Failed.");
            }
            return returnValue;
    }

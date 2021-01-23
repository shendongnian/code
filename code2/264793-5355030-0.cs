    private static IEnumerable<string> LoadWords(String filePath)
        {
    
            List<String> words = new List<String>();
    
            try
            {
                foreach (String line in File.ReadAllLines(filePath))
                {
                    string[] rows = line.Split(',');
                    
                    foreach(string str in rows)
                           words.Add(str);
                }
    
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
    
                return words;
        }

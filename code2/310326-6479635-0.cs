       static IEnumerable<string> ReadFromFile(string file) 
        {// check if file exist, null or empty string
            string line;
            using(var reader = File.OpenText(file)) 
            {
                while((line = reader.ReadLine()) != null) 
                {
                    yield return line;
                }
            }
        }

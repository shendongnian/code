    public string ReadFromFile(string fileName)
            {
                using(System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                using(System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                   return = reader.ReadToEnd();
                }
            }

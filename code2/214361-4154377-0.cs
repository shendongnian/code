        /// <summary>
        /// Save all information needed set current game state into given file.
        /// </summary>
        /// <param name="fileName"></param>
        public void save(string fileName)
        {
       Dictionary<string, string> attributes = new Dictionary<string, string>();
       attributes.Add("blue", "very");
       attributes.Add("red", "not");
    
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
    
            // Request the current state of all registered
     // objects and save them into the file.
       foreach (KeyValuePair<string, string> storeOnDisk in attributes)
        bFormatter.Serialize(stream, storeOnDisk);
    
            stream.Close();
        }

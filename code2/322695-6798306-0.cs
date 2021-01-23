    string theString = new string('*', 1022574);
    
    byte[] allData = System.Text.Encoding.UTF8.GetBytes(theString);
    int numberOfChunks = (int)Math.Ceiling((double)(allData.Length) / 2048);
    List<byte[]> chunks = new List<byte[]>(numberOfChunks);
    
    for (int i = 0; i < numberOfChunks; i++) {
    	chunks.Add(allData.Skip(i * 2048).Take(2048).ToArray());
    }

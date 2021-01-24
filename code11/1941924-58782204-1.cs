    private string ReadFromFile(string fileName)
    {
        string filePath = GetFilePath(fileName);
        var output = "";
        if (File.Exists(filePath))
        {
            print($"reading from {filePath}");
            using(StreamReader reader = new StreamReader(filePath))
            {
                output = reader.ReadToEnd();
                return output;
            }
        }
        // In this case rather try to read from streaming assets
        else
        {
            var altFilePath = Path.Combine(Application.streamingAssetsPath, fileName);
            if(File.Exists(altFilePath)
            {
                // read from here but directly also write it back to persistentDataPath
                print($"reading from {altFilePath}");
              
                using(StreamReader reader = new StreamReader(altFilePath))
                {
                    output = reader.ReadToEnd();
                }
                // Now before returning also write it to persistentDataPath
                WriteTopFile(fileName, output);
                return output;
            }
            else
            {
                Debug.LogError("File not found");
                return output;
            }
        }
    }

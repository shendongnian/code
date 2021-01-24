    private string ReadFromFile(string fileName)
    {
        var filePath = GetFilePath(fileName);
        var output = "";
        Debug.Log($"Trying to read file {filePath}");
        if (File.Exists(filePath))
        {
            Debug.Log($"File found! Reading from {filePath}");
            using(StreamReader reader = new StreamReader(filePath))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }
        // Otherwise rather try to read from streaming assets
        var altFilePath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.LogWarning($"File not found! Instead trying to read file {altFilePath}");
        if(File.Exists(altFilePath)
        {
            // read from here but directly also write it back to persistentDataPath
            Debug.Log($"File found. Reading from {altFilePath}");
            // As mentioned for Android you would now do the rest in a Coroutine 
            // using a UnityWebRequest.Get              
            using(StreamReader reader = new StreamReader(altFilePath))
            {
                output = reader.ReadToEnd();
            }
            // Now before returning also write it to persistentDataPath
            WriteTopFile(fileName, output);
            return output;
        }
        // If this also fails you didn't put such a file to `Assets/StreamingAssets` before the build
        Debug.LogError($"File also not found in {altFilePath}/n/nRemember to play it in 'Assets/StreamingAssets' before building!");
        return output;
    }

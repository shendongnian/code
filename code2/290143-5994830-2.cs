    var hashToNameMap = new Dictionary<string, string>();
    foreach (string file in files)
    {
        byte[] hash = Sha256HashFile(file);
        string base64 = Convert.ToBase64(hash);
        string existingName;
        if (hashToNameMap.TryGetValue(base64, out existingName))
        {
            Console.WriteLine("{0} is a duplicate of {1}", file, existingName);
        }
        else
        {
            hashToNameMap[base64] = file;
        }
    }

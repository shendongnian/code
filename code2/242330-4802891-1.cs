    // Serialize the table
    var serializer = new DataContractSerializer(typeof(DataTable));
    var memoryStream = new MemoryStream();
    serializer.WriteObject(memoryStream, table);
    byte[] serializedData = memoryStream.ToArray();
    
    // Calculte the serialized data's hash value
    var SHA = new SHA1CryptoServiceProvider();
    byte[] hash = SHA.ComputeHash(serializedData);
    
    // Convert the hash to a base 64 string
    string hashAsText = Convert.ToBase64String(hash);

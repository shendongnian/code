    [When(@"I receive a file([\w\s]+) notification with information([\w\s]+)")]
    public void WhenIReceiveNotification(string code, string tnCode)
    {
        string fileName = "Refund.json";
        string newId = ReplaceId(fileName);
        Dictionary<string, string> names = new Dictionary<string, string> {
            { "REFUND", fileName}
        };
        // ... your logic
    }
    
    private void ReplaceId(string fileName) {
    
        // Read file content and parse the JSON into an object
        string json = File.ReadAllText(fileName);
        var obj = JsonConvert.DeserializeObject(json);
        // Replace the ID with a new one.
        string newId = Guid.NewGuid().ToString("N");
        obj.Id = newId;
        // Serialize the object with the new ID, and write it back to the file
        string newJson = JsonConvert.SerializeObject(obj);
        File.WriteAllText(fileName, newJson);
        // Return the new file name to the caller.
        return newId;
    }

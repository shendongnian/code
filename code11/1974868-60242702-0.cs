private string FileR ( string name )
{
    // ReadSite always returns a content that has length 0 or more. string[] content will never equals null.
    string[] content = ReadSite(name, Protocol.read, url);
    Request_Template newCon;
    string[] final = new string[content.Length];
    
    // if content.Length == 0, this loop will never occur and you wont get any NREs.
    for (int i = 0; i < content.Length; i++)
    {
        // I dont believe you would get an error here because if content.length > 0, that would mean there is at least 1 line that can be read. Since its a string array, you should always check, string.IsNullOrEmpty(content[i]) which would cover the case its a space.
        if (content[i].Equals(null))
        {
            return "content [" + i + "] returns null";
        }
        // If you have checked that content[i] is Not empty space or null, you might end up with newCon == null if Deserialization fails. Cover this around try / catch.
        newCon = JsonSerializer.Deserialize<Request_Template>(content[i]);
        // If deserialization fails, this will throw NRE because nulls wont have Sender as a property or array. Check if newCon == null or not. Also, check if Sender was correctly initialized as an array.. as it could be null.
        if (newCon.Sender.Contains(myAccount.Username))
        {
            newCon.Sender = "Me";
        }
        string sender = newCon.Sender;
        string message = newCon.Message;
        // This should work correctly as its dependent on content.length. If the loop is happening, then there is at least one final element that can be updated.
        final[i] = sender + ":\t" + message;
    }
    string nFinal = string.Concat(final);
    Thread.Sleep(10);
    return nFinal;
}

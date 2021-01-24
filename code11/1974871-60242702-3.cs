private string FileR ( string name )
{
    // ReadSite always returns a content that has length 0 or more. string[] content will never equals null. 
    // TEST: string[] test = new string[0]; test == null -> False
    string[] content = ReadSite(name, Protocol.read, url);
    Request_Template newCon;
    string[] final = new string[content.Length];
    
    // if content.Length == 0, this loop will never occur and you wont get any NREs.
    for (int i = 0; i < content.Length; i++)
    {
        // It is highly unlikely that a reader.ReadLine() would generate a null but 
        // just in case it does, use == null instead of .Equals() method. When content[i] == null, you cannot use .Equals() method since nulls dont have Equals method.
        if (content[i].Equals(null))
        {
            return "content [" + i + "] returns null";
        }
        // If you have checked that content[i] is Not empty space or null, you might 
        //end up with newCon == null if Deserialization fails. Cover this around try / catch.
        newCon = JsonSerializer.Deserialize<Request_Template>(content[i]);
        // If deserialization fails, this will throw NRE because nulls wont have 
        // Sender as a property or array. Check if newCon == null or not. Also, 
        // check if Sender was correctly initialized as an array/list.. as it could 
        // be null. nulls wont have Contains as a method.
        if (newCon.Sender.Contains(myAccount.Username))
        {
            newCon.Sender = "Me";
        }
        string sender = newCon.Sender;
        string message = newCon.Message;
        // This should work correctly as its dependent on content.length. If the 
        // loop is happening, then there is at least one final element that can be updated.
        final[i] = sender + ":\t" + message;
    }
    string nFinal = string.Concat(final);
    Thread.Sleep(10);
    return nFinal;
}

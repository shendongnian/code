        string[] arr = clientMessage.Split('\n');
        foreach (string item in arr)
        {
             if(!string.IsNullOrEmpty(item))
                 recievedCommands.Enqueue(item);
         }
    

        Console.WriteLine("Got this message {0} back from the server", recieveMessage); // This part will simply remove the annoying numbers after the newsgroup name int 
        firstSpaceIndex = recieveMessage.IndexOf(" "); 
        string refactoredGroupName = recieveMessage.Substring(0, firstSpaceIndex);
        newsgroups.Add(new Newsgroup { GroupName = refactoredGroupName }); 
        recieveMessage = reader.ReadLine();
    }

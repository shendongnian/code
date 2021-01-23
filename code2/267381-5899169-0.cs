    var client = new ImapClient(...);
    client.Connection();
    client.LogIn(...);
          
    foreach (var item in WalkFolderTree(client.Folders))
    {
               
         Console.WriteLine(item.FolderPath);
     }
    client.LogOut();

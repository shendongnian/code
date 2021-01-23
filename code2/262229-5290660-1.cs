     List<string> serverNames = new List<string>();
     foreach (var server in GetAvailableServers())
     {
         if (server.IsAvailable)
         {
             serverNames.Add( server );
         }
     }

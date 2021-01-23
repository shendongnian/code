    int iisNumber = 1; // Default Website is IIS#1
    using(ServerManager serverManager = new ServerManager())
    {
      Site site = serverManager.Sites.FirstOrDefault(s => s.Id == iisNumber);
      if(site != null)
      {
        Binding binding = site.Bindings
            .Where(b => b.BindingInformation == "*:80:" && b.Protocol == "http")
            .FirstOrDefault();
    
        binding.BindingInformation = "*:90:";
    
        serverManager.CommitChanges();
        Console.WriteLine("");
      }
    }

    using(ServerManager serverManager = new ServerManager())
    {
      Site site = serverManager.Sites.FirstOrDefault(s => s.Id == 1);
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

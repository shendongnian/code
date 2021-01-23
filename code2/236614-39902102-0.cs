    public static bool DomainExistsNoForests(string domain, string server)
    {
      try {
        DirectoryContext directoryContext = new DirectoryContext(DirectoryContextType.DirectoryServer, server);
        Domain d = Domain.GetDomain(directoryContext);
        if (d.Name.Trim().Equals(domain.Trim(), StringComparison.CurrentCultureIgnoreCase)) return true;
        return false;
      }
      catch (Exception e) {
        return false;
      }
    }

    public List<String> ListNetworkComputers()
    {
        List<String> _ComputerNames = new List<String>();
        String _ComputerSchema = "Computer";
        System.DirectoryServices.DirectoryEntry _WinNTDirectoryEntries = new System.DirectoryServices.DirectoryEntry("WinNT:");
        foreach (System.DirectoryServices.DirectoryEntry _AvailDomains in _WinNTDirectoryEntries.Children)
        {
            foreach (System.DirectoryServices.DirectoryEntry _PCNameEntry in _AvailDomains.Children)
            {
                if (_PCNameEntry.SchemaClassName.ToLower().Contains(_ComputerSchema.ToLower()))
                {
                    _ComputerNames.Add(_PCNameEntry.Name);
                }
            }
        }
        return _ComputerNames;
    }

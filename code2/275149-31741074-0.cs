    public static bool IsSubpathOf(string rootPath, string subpath)
    {
        if (string.IsNullOrEmpty(rootPath))
            throw new ArgumentNullException("rootPath");
        if (string.IsNullOrEmpty(subpath))
            throw new ArgumentNulLException("subpath");
        Contract.EndContractBlock();
    
        return subath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase);
    }

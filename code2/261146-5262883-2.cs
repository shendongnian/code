    public string CreateEscapedIdentifier(string name)
    {
        if (!IsKeyword(name) && !IsPrefixTwoUnderscore(name))
        {
            return name;
        }
        return ("@" + name);
    }

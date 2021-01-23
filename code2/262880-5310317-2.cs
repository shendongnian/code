    public string GetDepartment(Principal principal)
    {
        string result = string.Empty;
        DirectoryEntry de = (principal.GetUnderlyingObject() as DirectoryEntry);
        if (de != null)
        {
           if (de.Properties.Contains("department"))
           {
              result = de.Properties["department"][0].ToString();
           }
        }
        return result;
    }

    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
    byte[] cypher = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
    //... reverse
    byte[] bytes = ProtectedData.Unprotect(cypher, null, DataProtectionScope.CurrentUser);
    string password = System.Text.Encoding.UTF8.GetString(bytes);

    List<string> passwords = new List<string>();
    while (passwords.Length < 1000)
    {
        string generated = System.Web.Security.Membership.GeneratePassword(
                               10, // maximum length
                               3)  // number of non-ASCII characters.
        if (!passwords.Contains(generated))
            passwords.Add(generated);
    }

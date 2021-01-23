    private static void GrantLogonAsServiceRight(string username)
    {
       using (LsaWrapper lsa = new LsaWrapper())
       {
          lsa.AddPrivileges(username, "SeServiceLogonRight");
       }
    }

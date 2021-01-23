    public bool Authenticate(string username, string password, string domain) {
        bool authenticated = false;
        using (DirectoryEntry entry = new DirectoryEntry(@"WinNT://" + domain, username, password) {
            try {
                object nativeObject = entry.NativeObject;
                authenticated = true;
            } catch (DirectoryServicesCOMException ex) {
            }
        }
        return authenticated;
    }

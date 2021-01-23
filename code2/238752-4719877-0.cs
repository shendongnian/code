    private static IsolatedStorageFile _isoStore =
                        IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
    String state = "my Secret String";
                using (IsolatedStorageFileStream oStream =
                        new IsolatedStorageFileStream(C_CREDENTIALS_FILENAME, 
                                                        FileMode.Create, 
                                                        _isoStore))
                {
                    Byte[] stateBytes = Encoding.Unicode.GetBytes(state);
                    Byte[] encryptedBytes = ProtectedData.Protect(stateBytes, 
                                                                    null, 
                                                                    DataProtectionScope.CurrentUser);
                    oStream.Write(encryptedBytes, 0, encryptedBytes.Length);

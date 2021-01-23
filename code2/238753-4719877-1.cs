    string[] fileNames = _isoStore.GetFileNames(C_CREDENTIALS_FILENAME);
                if (fileNames.Any(item => item == C_CREDENTIALS_FILENAME))
                {
                    //it exists
                    using (IsolatedStorageFileStream iStream =
                        new IsolatedStorageFileStream(C_CREDENTIALS_FILENAME, FileMode.Open, _isoStore))
                    {
                        Byte[] unEncryptedBytes = ProtectedData.Unprotect(iStream.ToArray(),
                                                    null,
                                                    DataProtectionScope.CurrentUser);
                        String unEncryptedXml = Encoding.Unicode.GetString(unEncryptedBytes);
                                        }
                }
                else
                { 
                    //it doesn't exist
                    return null;
                }
            }

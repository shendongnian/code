     while (true)
                {
                    clipboardText = GetTextClipboard();
                    switch ((clipboardText))
                    {
                        case "md5":
                            ShowNotification("MD5 HASHER", "Copy what you want to hash to md5");
                            {
                                string source = GetTextClipboard();
                                using (MD5 md5Hash = MD5.Create())
                                {
                                    string hash = GetMd5Hash(md5Hash, source);
                                    ShowNotification("", "The MD5 hash is" + hash + ".");
                                    ShowNotification("", "Verifying the hash...");
                                    if (VerifyMd5Hash(md5Hash, source, hash))
                                    {
                                        ShowNotification("", "The hashes are the same.");
                                    }
                                    else
                                    {
                                        ShowNotification("", "The hashes are not same.");
                                    }
                                }
                            }
                            break;
    
                    }
    Thread.Sleep (2000); 
                }

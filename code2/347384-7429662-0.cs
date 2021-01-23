           using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
            {
                if (unc.NetUseWithCredentials(path,
                                              userName,
                                              domain,
                                              passWord,textFile))
                {
                    System.Diagnostics.Process.Start(path);
                }
     
            }

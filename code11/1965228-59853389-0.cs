        private async Task GetUxVersionsFromServer()
        {
            string path = @$"\\{server}\...";
            
            if (Environment.UserDomainName.ToLower() != "myDomain")
            {
                bool success = false;
                bool ok;
                do
                {                    
                    (bool result, var username, var password) = _dialogService.ShowPasswordInput();
                    ok = result;
                    if (ok)
                    {
                        try
                        {
                            using (new NetworkConnection(path, new NetworkCredential($@"myDomain\{username}", password)))
                            {
                                success = await GetFiles(path);                                
                            }
                        }
                        catch (System.ComponentModel.Win32Exception ex)
                        {
                            success = false;
                        }
                        
                    } 
                } while (!success && ok);
                if(!ok)
                {
                    int test = 0;
                }
            }
            else
            {
                await GetFiles(path);
            }
        }

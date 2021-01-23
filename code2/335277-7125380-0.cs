                    //Retry logic on opening the connection
                    int retries = 0;
                    openconnection:
                        try
                        {
                            connection.Open();
                        }
                        catch
                        {
                            retries++;
                            //Wait 2 seconds
                            System.Threading.Thread.Sleep(2000);
                            if (retries < MAXRETRIES)
                            {
                                goto openconnection;
                            }
                            else
                            {
                                throw;
                            }
                        }

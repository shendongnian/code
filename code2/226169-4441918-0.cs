                void Write(object[] args) 
                {
                       this.ReaderWriterLock.AquireWriteLock(TimeOut.Infinite);
                  
                        try 
                        {
                          this.myData.Write(args);
                        }
                        catch(Exception ex) 
                        {
                                 
                        }
                        finally 
                        {
                            this.ReaderWriterLock.RelaseWriterLock();
                        }
                }

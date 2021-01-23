                cacheLock.EnterReadLock();
                try
                {
                    //LockRecursionException here
                    _PrincipalMap[key] = Thread.CurrentPrincipal;
                }
                finally
                {
                    cacheLock.ExitReadLock();
                }

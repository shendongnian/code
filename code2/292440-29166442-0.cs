        private void LockWithTimeout(object p_oLock, int p_iTimeout, Action p_aAction)
        {
            Exception eLockException = null;
            bool bLockWasTaken = false;
            try
            {
                Monitor.TryEnter(p_oLock, p_iTimeout, ref bLockWasTaken);
                if (bLockWasTaken)
                    p_aAction();
                else
                    throw new Exception("Timeout exceeded, unable to lock.");
            }
            catch (Exception ex)
            {
                // conserver l'exception
                eLockException = ex;
            }
            finally 
            { 
                // release le lock
                if (bLockWasTaken) 
                    Monitor.Exit(p_oLock); 
                // relancer l'exception
                if (eLockException != null)
                    throw new Exception("An exception occured during the lock proces.", eLockException);
            }
        }

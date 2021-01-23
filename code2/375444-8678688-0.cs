        public static bool WaitAnotherMsiInstallation(int timeout)
        {
            const string MsiMutexName = "Global\\_MSIExecute";
            try
            {
                using (var msiMutex = Mutex.OpenExisting(MsiMutexName, MutexRights.Synchronize))
                {
                    return msiMutex.WaitOne(timeout);
                }
            } 
            catch (WaitHandleCannotBeOpenedException)
            {
                // The named mutex does not exist.
                return true;
            }
            catch (ObjectDisposedException)
            {
                // Mutex was disposed between opening it and attempting to wait on it
                return true;
            }
        }

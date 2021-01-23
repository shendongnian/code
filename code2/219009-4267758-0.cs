        static bool CheckPermissions()
        {
            try
            {
                Mutex mutex = Mutex.OpenExisting("MyPermissions");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

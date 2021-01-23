    class LockManager
    {
        private static Object managerLock = new Object();
        private static Dictionary<string, int> fileLocks = new Dictionary<string, int>();
        private static Dictionary<string, int> folderLocks = new Dictionary<string, int>();
        public static void EnterFolderLock(string folderPath)
        {
            Monitor.Enter(managerLock);
            string aLocked;
            // test if all subfolders are not locked
            do
            {
                aLocked = null;
                foreach (KeyValuePair<string, int> folderLock in folderLocks)
                {
                    // if it is in a locked folder
                    if (folderPath.Contains(folderLock.Key))
                    {
                        aLocked = folderLock.Key;
                        break;
                    }
                    else if (folderLock.Key.Contains(folderPath))
                    {
                        aLocked = folderLock.Key;
                        break;
                    }
                }
                if (aLocked == null)
                {
                    foreach (KeyValuePair<string, int> fileLock in fileLocks)
                    {
                        // if it has a locked file
                        if (fileLock.Key.Contains(folderPath))
                        {
                            aLocked = fileLock.Key;
                            break;
                        }
                    }
                }
                if (aLocked != null)
                {
                    Monitor.Exit(managerLock);
                    // wait until the lock was released
                    Monitor.Enter(aLocked);
                    Monitor.Exit(aLocked);
                    Monitor.Enter(managerLock);
                }
            } while (aLocked != null);
            if (folderLocks.ContainsKey(folderPath))
            {
                folderLocks[folderPath] = folderLocks[folderPath] + 1;
            }
            else
            {
                folderLocks.Add(folderPath, 1);
            }
            Monitor.Exit(managerLock);
            // get the file lock
            Monitor.Enter(folderPath);
        }
        public static void EnterFileLock(string filePath)
        {
            Monitor.Enter(managerLock);
            string aLockedFolder;
            // test if all subfolders are not locked
            do
            {
                aLockedFolder = null;
                foreach (KeyValuePair<string, int> folderLock in folderLocks)
                {
                    // if it is in a locked folder
                    if (filePath.Contains(folderLock.Key))
                    {
                        aLockedFolder = folderLock.Key;
                        break;
                    }
                }
                if (aLockedFolder != null)
                {
                    Monitor.Exit(managerLock);
                    // wait until the lock was released
                    Monitor.Enter(aLockedFolder);
                    Monitor.Exit(aLockedFolder);
                    Monitor.Enter(managerLock);
                }
            } while (aLockedFolder != null);
            if (fileLocks.ContainsKey(filePath))
            {
                fileLocks[filePath] = fileLocks[filePath] + 1;
            }
            else
            {
                fileLocks.Add(filePath, 1);
            }
            Monitor.Exit(managerLock);
            // get the file lock
            Monitor.Enter(filePath);
        }
        public static void ExitFolderLock(string folderPath)
        {
            Monitor.Enter(managerLock);
            if (!folderLocks.ContainsKey(folderPath))
            {
                // key is missing!!!
                throw new Exception("Can't exit this folder lock if it's not open!");
            }
            else if (folderLocks[folderPath] == 0)
            {
                // key is missing!!!
                throw new Exception("Can't exit this folder lock if it's not open! Something strange happened. Please debug.");
            }
            else if (folderLocks[folderPath] == 1)
            {
                // last entry remove
                folderLocks.Remove(folderPath);
            }
            else
            {
                folderLocks[folderPath] = folderLocks[folderPath] - 1;
            }
            Monitor.Exit(folderPath);
            Monitor.Exit(managerLock);
        }
        public static void ExitFileLock(string filePath)
        {
            Monitor.Enter(managerLock);
            if (!fileLocks.ContainsKey(filePath))
            {
                // key is missing!!!
                throw new Exception("Can't exit this file lock if it's not open!");
            }
            else if (fileLocks[filePath] == 0)
            {
                // key is missing!!!
                throw new Exception("Can't exit this file lock if it's not open! Something strange happened. Please debug.");
            }
            else if (fileLocks[filePath] == 1)
            {
                // last entry remove
                fileLocks.Remove(filePath);
            }
            else
            {
                fileLocks[filePath] = fileLocks[filePath] - 1;
            }
            Monitor.Exit(filePath);
            Monitor.Exit(managerLock);
        }
    }

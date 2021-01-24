        /// <summary>
        /// Creates something or other.  
        /// </summary>
        /// <param name="HKEY">0 = CurrentUser, 1 = LocalMachine, 2 = ClassesRoot, 3 = Users, 4 = CurrentConfig</param>
        /// <param name="keypath">The key path.</param>
        /// <param name="keyname">The key name.</param>
        /// <param name="keyvalue">The key value</param>
        public static void Create(int HKEY, string keypath, string keyname, int keyvalue)

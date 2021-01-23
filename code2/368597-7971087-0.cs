        /// <summary>
        /// Singleton that retrieves and stores the common list of permissions.
        /// </summary>
        public static class Permissions
        {
            private static List<String> instance = null;
    
            /// <summary>
            /// Gets the permissions.
            /// </summary>
            /// <returns></returns>
            static public List<String> GetPermissions()
            {
                if (instance == null)
                    instance = DatabaseHelper.GetPermissionsFromDatabase();
    
                return instance;
            }
        }

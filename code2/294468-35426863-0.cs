        /// <summary>
        /// Check if data table is exist in application
        /// </summary>
        /// <typeparam name="T">Class of data table to check</typeparam>
        /// <param name="db">DB Object</param>
        public static bool CheckTableExists<T>(this ModelLocker db) where T : class
        {
            try
            {
                return db.Set<T>().Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

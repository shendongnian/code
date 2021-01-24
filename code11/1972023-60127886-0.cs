    public class DeviceService
	{
        private const string databaseName = "eTabber.db";
        public static string StoragePath { get; set; }
        /// <summary>
        /// Return the device specific database path for SQLite
        /// </summary>
        public static string GetSQLiteDatabasePath()
		{
            return Path.Combine(StoragePath, databaseName);
        }
	}

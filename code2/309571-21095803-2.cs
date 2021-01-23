        /// <summary>
        /// Gets the name of an ODBC driver for Microsoft SQL Server giving preference to the most recent one.
        /// </summary>
        /// <returns>the name of an ODBC driver for Microsoft SQL Server, if one is present; null, otherwise.</returns>
        public static string GetOdbcSqlDriverName()
        {
            List<string> driverPrecedence = new List<string>() { "SQL Server Native Client 11.0", "SQL Server Native Client 10.0", "SQL Server Native Client 9.0", "SQL Server" };
            string[] availableOdbcDrivers = GetOdbcDriverNames();
            string driverName = null;
            if (availableOdbcDrivers != null)
            {
                driverName = driverPrecedence.Intersect(availableOdbcDrivers).FirstOrDefault();
            }
            return driverName;
        }

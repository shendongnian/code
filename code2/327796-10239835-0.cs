        /// <summary>
        /// Execute Stored Proc with result set returned.
        /// </summary>
        /// <param name="procName"></param>
        /// <returns>An object resultset</returns>
        T ExecuteCustomStoredProc<T>(string procName, SqlParameter params);

    public static class WinErrors
    {
        /// <summary>
        /// Gets a user friendly string message for a system error code
        /// </summary>
        /// <param name="errorCode">System error code</param>
        /// <returns>Error string</returns>
        public static string GetSystemMessage(uint errorCode)
        {
            var exception = new Win32Exception((int)errorCode);
            return exception.Message;
        }
    }

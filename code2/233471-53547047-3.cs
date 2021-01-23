        /// <summary>
        /// Uses concatenated then SubStringed GUIDs to get a random string of the
        /// desired length. Relies on the randomness of the GUID generation algorithm.
        /// </summary>
        /// <param name="stringLength">Length of string to return</param>
        /// <returns>Random string of <paramref name="stringLength"/> characters</returns>
        internal static string GetRandomString(int stringLength)
        {
            StringBuilder sb = new StringBuilder();
            int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
            for(int i = 1; i <= numGuidsToConcat; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }
            return sb.ToString(0, stringLength);
        }

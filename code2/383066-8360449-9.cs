        /// <summary>
        /// This method removes all invalid characters from the specified file name.
        /// Note that ONLY the file name should be passed, not the directory name.
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string CleanFileName(string sFileName)
        {
            // Exceptions are handled by the caller
            // If there are any invalid characters in the file name
            if (sFileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                // Strip them out (split to remove the characters, then rejoin the pieces into one string)
                return string.Join("", sFileName.Split(System.IO.Path.GetInvalidFileNameChars()));
            }
            else
            {
                return sFileName;
            }
        }

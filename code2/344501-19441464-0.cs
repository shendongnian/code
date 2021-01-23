        /// <summary>
        /// Get the extension from the given filename
        /// </summary>
        /// <param name="fileName">the given filename ie:abc.123.txt</param>
        /// <returns>the extension ie:txt</returns>
        public static string GetFileExtension(this string fileName)
        {
            string ext = string.Empty;
            int fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (fileExtPos >= 0)
                ext = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);
            return ext;
        }

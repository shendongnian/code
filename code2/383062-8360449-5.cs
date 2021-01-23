        /// <summary>
        /// This method generates a standard list of extension to content-disposition tags
        /// The key for each item is the file extension without the leading period. The value 
        /// is the content-disposition.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Collections.Generic.Dictionary<string, string> GenerateStandardMimeList()
        {
            // Exceptions are handled by the caller.
            System.Collections.Generic.Dictionary<string, string> cItems = new Dictionary<string, string>();
            cItems.Add("jpeg", "image/jpeg");
            cItems.Add("jpg", "image/jpeg");
            cItems.Add("pdf", "application/pdf");
            
            return cItems;
        }

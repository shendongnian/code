        /// <summary>
        /// Changes the file name of the <paramref name="uri"/> using the given <paramref name="modifier"/>
        /// </summary>
        /// <param name="uri">A relative or absolute uri</param>
        /// <param name="modifier">A function to apply to the filename</param>
        /// <returns>The modified uri</returns>
        public static string ModifyUriFileName(string uri, Func<string, string> modifier)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException("uri");
            }
            var fileName = Path.GetFileNameWithoutExtension(uri);
            var extension = Path.GetExtension(uri);
            var path = uri.Substring(0, uri.LastIndexOf('/') + 1);
            return string.Format("{0}{1}{2}", path, modifier(fileName), extension);
        }

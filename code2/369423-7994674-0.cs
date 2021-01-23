        /// <summary>
        /// Gets the dynamic references.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="assemblyDllPath">The assembly DLL path.</param>
        /// <returns></returns>
        private string[] GetDynamicReferences(string source, string assemblyDllPath)
        {
            var filenames = new List<string>();
            const string startRegion = "#region References";
            const string endRegion = "#endregion";
            const string commentStart = "/*";
            const string commentEnd = "*/";
            const string commentLine = "//";
            const string libpath = "/libpath";
            var sourceReader = new StringReader(source);
            string currentLine;
            bool inReferenceRegion = false;
            bool inReferenceCommentRegion = false;
            // Loop over the lines in the script and check each line individually.
            while ((currentLine = sourceReader.ReadLine()) != null)
            {
                // Strip the current line of all trailing spaces.
                currentLine = currentLine.Trim();
                // Check if we're entering the region 'References'.
                if (currentLine.StartsWith(startRegion))
                {
                    inReferenceRegion = true;   // We're entering the region, set the flag.
                    continue;                   // Skip to the next line.
                }
                // Check if we're exiting the region 'References'. If so, stop the for loop.
                if (currentLine.StartsWith(endRegion)) break;
                // If we're processing a line that's not in the 'References' region, then skip the line
                // as we're only interested in the lines from that region.
                if (!inReferenceRegion) continue;
                // Check if we're entering the comments section, because the entire region is actually
                // a big comment block, starting with /*
                if (currentLine.StartsWith(commentStart))
                {
                    inReferenceCommentRegion = true;    // We're entering the comment block.
                    continue;                           // Skip to the next line.
                }
                // Check if we're leaving the comments section, because then we're almost done parsing
                // the entire comment block.
                if (currentLine.EndsWith(commentEnd))
                {
                    inReferenceCommentRegion = false;   // Leaving the comment block.
                    continue;                           // Skip to the next line.
                }
                // If the line we're processing starts with a comment '//', then skip the line because it's
                // not to be processed anymore by us, just as if it was placed in comment in real code.
                // If the line contains a double slash, strip one of the slashes from it and parse the data.
                if (currentLine.Contains(commentLine))
                {
                    if (currentLine.StartsWith(commentLine)) continue;
                    currentLine = currentLine.Substring(0, currentLine.IndexOf(commentLine) - 1);
                }
                // If we're dealing with a line that's not inside the reference comment section, skip it
                // because we're only interested in the lines inside the comment region section of the script.
                if (!inReferenceCommentRegion) continue;
                // Trim the current line of all trailing spaces, the line should represent either the fullpath
                // to a DLL, the librarypath option, or the relative path of a DLL.
                string line = currentLine.Trim();
                // If the line starts with the library option, then we need to extract this information, and store it
                // inside the local varialbe that holds the libpath.
                if (line.Equals(libpath))
                {
                    string dataHomeFolder = Api2.Factory.CreateApi().Parameters.Read(343).Value;
                    string companyName = Api2.Factory.CreateApi().Parameters.Read(113).Value;
                    _libraryPath = Path.Combine(dataHomeFolder, companyName, "libraries");
                }
                // If the line is not an absolute path to the referenced DLL, then we need to assume that the DLL resides
                // in the library path. We'll build up the full path using the library path, if the path has been set.
                if (!Path.IsPathRooted(line) && !string.IsNullOrEmpty(_libraryPath))
                    line = Path.Combine(_libraryPath, line);                
                // If the file exists, then we'll add it as reference to the collection to be used by the compiler.
                // We will not copy the file however in the bin folder of the application.
                var fio = new FileInfo(line);
                if (fio.Exists && !filenames.Contains(line)) filenames.Add(line);
            }
            // Return the entire collection of libraries.
            return filenames.ToArray();
        }

    static class EmbeddedResource
    {
        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of your assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        public static Stream Open(string assemblyName, string fileName)
        {
            var asm = Assembly.Load(assemblyName);
            var stream = asm.GetManifestResourceStream(assemblyName + "." + fileName);
            if (stream == null)
                throw new ConfigurationErrorsException(String.Format(
                        Strings.MissingResourceErrorFormat, fileName, assemblyName));
            return stream;
        }
    }

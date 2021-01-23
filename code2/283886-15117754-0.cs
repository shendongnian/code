        /// <summary>
        /// Gets the current application directory.
        /// For class libraries and executables returns the executing directoy.
        /// For web applications returns the bin directory. This is important to find content relative to the assembly in the bin folder
        /// versus the actual executing location which maybe the shallow copy folder (Microsoft Asp.Net temporary folder).
        /// </summary>
        /// <returns>path to the appication directory</returns>
        public static string GetApplicationDirectory()
        {
            if (AppDomain.CurrentDomain.RelativeSearchPath != String.Empty && AppDomain.CurrentDomain.RelativeSearchPath != null)
                return AppDomain.CurrentDomain.RelativeSearchPath;
            else
                //if null check normal way     
                return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

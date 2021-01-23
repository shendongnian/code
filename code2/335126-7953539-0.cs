        /// <summary>
        /// Adds an environment path segments (the PATH varialbe).
        /// </summary>
        /// <param name="pathSegment">The path segment.</param>
        public static void AddPathSegments(string pathSegment)
        {
            LogHelper.Log(LogType.Dbg, "EnvironmentHelper.AddPathSegments", "Adding path segment: {0}", pathSegment);
            string allPaths = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);
            if (allPaths != null)
                allPaths = pathSegment + "; " + allPaths;
            else
                allPaths = pathSegment;
            Environment.SetEnvironmentVariable("PATH", allPaths, EnvironmentVariableTarget.Process);
        }

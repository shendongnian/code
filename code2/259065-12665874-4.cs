        /// <summary>
        /// Load the control with the given type.
        /// </summary>
        public object LoadControl(Type t, Page page)
        {
            try
            {
                // The definition for the resolver is in the next code bit
                var partialPath = resolver.ResolvePartialPath(t);
                var fullPath = ResolvePartialControlPath(partialPath);
                // Now we have the Control loaded from the Virtual Path. Easy.
                return page.LoadControl(fullPath);
            } catch (Exception ex)
            {
                throw new Exception("Control mapping failed", ex);
            }
        }
        /// <summary>
        /// Loads a control by a particular type.
        /// (Strong-typed wrapper for the previous method).
        /// </summary>
        public T LoadControl<T>(Page page) where T : Control
        {
            try
            {
                return (T)LoadControl(typeof (T), page);
            } catch (Exception ex)
            {
                throw new Exception(string.Format(
                    "Failed to load control for type: {0}",
                    typeof (T).Name), ex);
            }
        }
        /// <summary>
        /// Given a partial control path, return the full (relative to root) control path.
        /// </summary>
        string ResolvePartialControlPath(string partialPath)
        {
            return string.Format("{0}{1}.ascx",
                ControlPathRoot, partialPath);
        }

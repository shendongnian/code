    /// <summary>
    /// Looks in all loaded assemblies for the given type.
    /// </summary>
    /// <param name="fullName">
    /// The full name of the type.
    /// </param>
    /// <returns>
    /// The <see cref="Type"/> found; null if not found.
    /// </returns>
    private static Type FindType(string fullName)
    {
        return
            AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.FullName.Equals(fullName));
    }

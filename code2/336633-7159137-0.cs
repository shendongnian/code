    /// <summary>
    ///     Converts a path in a form suitable for comparison with other paths.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         In general case, two equivalent paths do not necessarily have the same string
    ///         representation. However, after subjecting them to this method, they will have
    ///         (case-insensitively) equal string representations.
    ///     </para>
    ///     <para>
    ///         Removes ".." and "." and always trims trailing path separator (except for paths
    ///         in format "X:\" or "\"). Does not change case.
    ///     </para>
    ///     <para>
    ///         This method does not attempt to validate the path (since its purpose is only to
    ///         make paths comparable as strings), so some logically incorrect paths will pass
    ///         through it unscathed. Examples of such paths include: "C:\..", "\..",
    ///         "\\machine\c$\..", "\\machine\c$\..\.." etc...
    ///     </para>
    /// </remarks>
    /// <returns>
    ///     Normalized path. Empty or <c>null</c> <paramref name="path"/> results in empty or
    ///     <c>null</c> result.
    /// </returns>
    /// <seealso cref="PathComparer"/>
    public static string NormalizePath(string path) {
        if (string.IsNullOrEmpty(path))
            return path;
        // Remove path root.
        string path_root = Path.GetPathRoot(path);
        path = path.Substring(path_root.Length);
        string[] path_components = path.Split(Path.DirectorySeparatorChar);
        // "Operating memory" for construction of normalized path.
        // Top element is the last path component. Bottom of the stack is first path component.
        Stack<string> stack = new Stack<string>(path_components.Length);
        foreach (string path_component in path_components) {
            if (path_component.Length == 0)
                continue;
            if (path_component == ".")
                continue;
            if (path_component == ".." && stack.Count > 0 && stack.Peek() != "..") {
                stack.Pop();
                continue;
            }
            stack.Push(path_component);
        }
        string result = string.Join(new string(Path.DirectorySeparatorChar, 1), stack.Reverse().ToArray());
        result = Path.Combine(path_root, result);
        return result;
    }

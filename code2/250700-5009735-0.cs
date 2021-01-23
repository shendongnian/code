    private IEnumerable<TreeNode> GetChildNodes(TreeNode parent)
    {
        string path = parent.Tag.ToString();
        if (String.IsNullOrEmpty (path) || String.IsNullOrWhiteSpace (path))
            yield break;
        // I'm not aware of a constant/enum for the maximum allowed path length here :(
        if (path.Length > 260 || path.Any (Path.GetInvalidPathChars ().Contains))
            yield break;
        if (!Directory.Exists (path))
            yield break;
        Func<string[], Func<string[],string>,> SafeIO = (fn, arg) => {
            try {
                return fn (p);
            } catch (IOException) {
                return new string[0];
            }
        };
        // Add Directories
        string[] subdirs = SafeIO (Directory.GetDirectories, path);
        foreach (string subdir in subdirs)
            yield return GetChildNode(subdir);
        // Add Files
        string[] files = SafeIO (Directory.GetFiles, path);
        foreach (string file in files) {
            var child = GetChildNode(file);
            fileNodeMap[file] = child;
            yield return child;
        }
    }

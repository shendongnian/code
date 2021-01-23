    public static void Main() {
        var siteRoot = new DirectoryEntry("IIS://<servername>/W3SVC/2/Root");
        var containsVirtualDirectory = ContainsVirtualDirectory(siteRoot);
    }
    private static Boolean ContainsVirtualDirectory(DirectoryEntry container) {
        foreach (DirectoryEntry child in container.Children) {
            if (child.SchemaClassName == "IIsWebVirtualDir")
                return true;
            if (child.SchemaClassName == "IIsWebDirectory" && ContainsVirtualDirectory(child))
                return true;
        }
        return false;
    }

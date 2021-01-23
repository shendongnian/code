    public boolean SessionObjectsPresent(params string[] names) {
        foreach (var name in names) {
            if (Session[name] == null) return false
        }
        return true;
    }
    if (SessionObjectsPresent("CurrentHost", "CurrentUrl")) {
        // ...
    }

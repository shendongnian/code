    var cas = new SecurityPermission(PermissionState.Unrestricted);
    try
    {
        cas.Assert();
        // ...
        var result = JavaScriptCompressor.Compress(output);
        // ...
    }
    finally
    {
        CodeAccessPermission.RevertAssert();
    }

    private static string MapUrl(string path)
    {
        var appPath = HttpContext.Current.Server.MapPath("~");
        return string.Format("~{0}", path.Replace(appPath, "").Replace("\\", "/"));
    }

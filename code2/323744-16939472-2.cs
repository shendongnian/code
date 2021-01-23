    public static string DataUriContent(this UrlHelper url, string path)
    {
        var filePath = HttpContext.Current.Server.MapPath(path);
        var sb = new StringBuilder();
        sb.Append("data:image/")
            .Append((Path.GetExtension(filePath) ?? "png").Replace(".", ""))
            .Append(";base64,")
            .Append(Convert.ToBase64String(File.ReadAllBytes(filePath)));
        return sb.ToString();
    }

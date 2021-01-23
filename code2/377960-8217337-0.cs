    public static string VersionedContent(this UrlHelper urlHelper, string contentPath)
    {
        string result = urlHelper.Content(contentPath);
        var versionService = Engine.IocService.GetInstance<IVersionService>();
        string tag = versionService.GetVersionTag();
        if (result.Contains('?'))
        {
            result += "&v="+tag;
        }
        else
        {
            result += "?v="+tag;
        }
        return result;
    }

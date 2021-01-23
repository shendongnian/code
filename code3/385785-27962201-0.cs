    public static bool WebExists(string absoluteUrl)
    {
        try
        {
            using (var site = new SPSite(absoluteUrl))
            {
                using (var web = site.OpenWeb())
                {
                    return web.Exists;
                }
            }
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }

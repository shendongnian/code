    public ActionResult Index(string keyword, int? page, int? size)
    {
        keyword = keyword ?? "";
        page = page ?? 1;
        size = size ?? GetSizeFromCookie() ?? 10;
    }
    private int? GetSizeFromCookie()
    {
        string cookieValue = Request.Cookies.Get("StoriesPageSize").Value;
        if (cookieValue == null)
        {
            return null;
        }
        int size;
        if (int.TryParse(cookieValue, out size))
        {
            return size;
        }
        // Couldn't parse...
        return null;
    }

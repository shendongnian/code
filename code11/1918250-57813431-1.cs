    public ActionResult GetMyJson()
    {
        var dict = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "1", new Dictionary<string, string>()
                {
                    { "1年期", "12" },
                    { "13個月期", "13" },
                    { "2年期", "24" },
                    { "3年期", "36" },
                }
            },
            {
                "2", new Dictionary<string, string>()
                {
                    { "1年期", "12" },
                    { "13個月期", "13" },
                    { "2年期", "24" },
                    { "3年期", "36" },
                }
            },
            {
                "3", new Dictionary<string, string>()
                {
                    { "1個月期", "1" },
                    { "3個月期", "3" },
                    { "6個月期", "6" },
                    { "9個月期", "9" },
                    { "1年期", "12" },
                    { "13個月期", "13" },
                    { "2年期", "24" },
                    { "3年期", "36" },
                }
            }
        };
    
        return Json(dict);
    }

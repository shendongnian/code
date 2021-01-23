    private static void ExpireCookies(HttpContext current)
        {
            var allCookies = current.Request.Cookies.AllKeys;
            foreach (var cook in allCookies.Select(c => current.Response.Cookies[c]).Where(cook => cook != null))
            {
                cook.Value = "";
                cook.Expires = DateTime.Now.AddDays(-1);
                current.Response.Cookies.Remove(cook.Name);
            }
        }

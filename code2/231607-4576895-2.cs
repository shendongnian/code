    public IEnumerable<Cookie> GetCookiesForUsers(IEnumerable<User> Users)
    {
        var cookies = from c in db.Cookies
                  join uc in db.UserCookies on c.CookieID equals uc.CookieID
                  join u in db.Users on uc.UserID equals u.UserID
                  where Users.Select(x => x.UserID).Contains(u.UserID)
                  select c;
        return cookies.ToList();
    }

        if (recentlyViewedCookie != null)
        {
            string value = recentlyViewedCookie.Value;
            value = string.Format("{0}|{1}*{2}", value, DateTime.Now.ToString("MM/dd/yyyy"), Request.Url.ToString());
            recentlyViewedCookie.Value = value;
            Response.Cookies.Add(recentlyViewedCookie);
        }

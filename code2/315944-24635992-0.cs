    public void AddToCookie(SessionUser sessionUser)
        {
            var httpCookie = HttpContext.Current.Response.Cookies["SessionUser"];
            if (httpCookie != null)
            {
                httpCookie["ID"] = sessionUser.ID.ToString();
                httpCookie["Name"] = sessionUser.Name;
                httpCookie["Email"] = sessionUser.Email;
                httpCookie["Phone"] = sessionUser.Phone;
                httpCookie.Expires = DateTime.Now.AddDays(1);
            }
        }

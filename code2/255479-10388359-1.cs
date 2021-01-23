    /// <summary>
    /// Deletes a cookie with specified name
    /// </summary>
    /// <param name="controller">extends the controller</param>
    /// <param name="cookieName">cookie name</param>
    public static void DeleteCookie(this Controller controller, string cookieName)
    {
        if (controller.HttpContext.Request.Cookies[cookieName] == null)
                return; //cookie doesn't exist
    
        var c = new HttpCookie(cookieName)
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
        controller.HttpContext.Response.Cookies.Add(c);
    }

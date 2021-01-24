    [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            var array = returnUrl.Split("/");
            if (array[1] == "en" || array[1] == "de")//returnUrl like ~/en/Home/privacy
            {
                array[1] = culture;
                return LocalRedirect(String.Join("/", array));
            }
            else// returnUrl like ~/Home/privacy
            {
                return LocalRedirect("/" + culture + returnUrl.Substring(1));
            }
            
        }

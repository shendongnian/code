        public static HttpCookie GetCookie(string cookieName)
        {
            HttpCookie rqstCookie = HttpContext.Current.Request.Cookies.Get(cookieName);
            /*** NOTE: it will not be on the Response!
             *   this will trigger the error noted in the original question and
             *   create a new, empty cookie which overrides it
             *   
                HttpCookie respCookie = HttpContext.Current.Response.Cookies.Get(cookieName);
             * 
             */
            if (rqstCookie != null && !String.IsNullOrEmpty(rqstCookie.Value))
            {
                // is found on the Request
                return rqstCookie;
            }
            else
            {
                return null;
            }
        }

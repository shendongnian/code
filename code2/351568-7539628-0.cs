        [DllImport("ieframe.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IESetProtectedModeCookie(string url, string name, string data, int flags);
        public static bool SetWinINETCookieString()
        {
          return IESetProtectedModeCookie("http://url.co.uk", "name", "data=blah; expires = Sat,01-Jan-2012 00:00:00 GMT; path=/", 0x10);
            
        }

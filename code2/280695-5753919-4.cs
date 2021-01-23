    public class WebUtils {
        CookieContainer _cookies;
        
        public WebUtils() {
            _cookies = new CookieContainer();
        }
        
        public void AccessPage(string url) {
            //Here I create a new instance of a HttpWebRequest class, and assign `_cookies` to its `Cookie` property.
            //Don't really know if `WebClient` has something similar
        }   
    }

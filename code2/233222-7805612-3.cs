    namespace [Your chosen namespace].ReCaptcha
    {
        public enum Theme { Red, White, BlackGlass, Clean }
    
        [Serializable]
        public class InvalidKeyException : ApplicationException
        {
            public InvalidKeyException() { }
            public InvalidKeyException(string message) : base(message) { }
            public InvalidKeyException(string message, Exception inner) : base(message, inner) { }
        }
    
        public class ReCaptchaAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var userIP = filterContext.RequestContext.HttpContext.Request.UserHostAddress;
    
                var privateKey = ConfigurationManager.AppSettings.GetString("ReCaptcha.PrivateKey", "");
    
                if (string.IsNullOrWhiteSpace(privateKey))
                    throw new InvalidKeyException("ReCaptcha.PrivateKey missing from appSettings");
    
                var postData = string.Format("&privatekey={0}&remoteip={1}&challenge={2}&response={3}",
                                             privateKey,
                                             userIP,
                                             filterContext.RequestContext.HttpContext.Request.Form["recaptcha_challenge_field"],
                                             filterContext.RequestContext.HttpContext.Request.Form["recaptcha_response_field"]);
    
                var postDataAsBytes = Encoding.UTF8.GetBytes(postData);
    
                // Create web request
                var request = WebRequest.Create("http://www.google.com/recaptcha/api/verify");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataAsBytes.Length;
                var dataStream = request.GetRequestStream();
                dataStream.Write(postDataAsBytes, 0, postDataAsBytes.Length);
                dataStream.Close();
    
                // Get the response.
                var response = request.GetResponse();
               
                using (dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        var responseFromServer = reader.ReadToEnd();
    
                        if (!responseFromServer.StartsWith("true"))
                            ((Controller)filterContext.Controller).ModelState.AddModelError("ReCaptcha", "Captcha words typed incorrectly");
                    }
                }
            }
        }
    
        public static class HtmlHelperExtensions
        {
            public static MvcHtmlString GenerateCaptcha(this HtmlHelper helper, Theme theme, string callBack = null)
            {
                const string htmlInjectString = @"<div id=""recaptcha_div""></div>
    <script type=""text/javascript"">
        Recaptcha.create(""{0}"", ""recaptcha_div"", {{ theme: ""{1}"" {2}}});
    </script>";
    
                var publicKey = ConfigurationManager.AppSettings.GetString("ReCaptcha.PublicKey", "");
    
                if (string.IsNullOrWhiteSpace(publicKey))
                    throw new InvalidKeyException("ReCaptcha.PublicKey missing from appSettings");
    
                if (!string.IsNullOrWhiteSpace(callBack))
                    callBack = string.Concat(", callback: ", callBack);
    
                var html = string.Format(htmlInjectString, publicKey, theme.ToString().ToLower(), callBack);
                return MvcHtmlString.Create(html);
            }
        }
    }

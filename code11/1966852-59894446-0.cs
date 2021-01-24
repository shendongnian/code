     public class RedirectUrlAction
    {
        private int value;
        public string GetActionUrl(string action, string controller, string DefaultRediretUrl, Func<int,Boolean> Condition, UrlHelper urlHrlper)
        {
            string url = "";
            if (Condition(value) == true)
            {
                urlHrlper.Action(action, controller);
            }
            else
            {
                url = DefaultRediretUrl;
            }
            return url;
        }
    }

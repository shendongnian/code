    public static class ExtensionMethods
    {
        public static void Blank(this IWebElement _el)
        {
            _el.SendKeys(Keys.Control + "a");
            _el.SendKeys("\b");
        }
    }

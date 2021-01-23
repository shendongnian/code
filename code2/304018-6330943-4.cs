    public class RebasingContainerBuilder : ControlBuilder
    {
        public override bool AllowWhitespaceLiterals()
        {
            return false;
        }
        public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
        {
            if (string.Equals(tagName, "link", StringComparison.OrdinalIgnoreCase))
            {
                return typeof(HtmlLink);
            }
            if (string.Equals(tagName, "script", StringComparison.OrdinalIgnoreCase)
                && attribs.Contains("src"))
            {
                //only rebase script tags that have a src attribute!
                return typeof(HtmlScript);
            }
            return null;
        }
    }

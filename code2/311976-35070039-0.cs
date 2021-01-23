    public static class HtmlGenericControlExtensions
    {
        public static void AddClassToHtmlControl(this HtmlGenericControl htmlGenericControl, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return;
            htmlGenericControl
                .Attributes.Add("class", string.Join(" ", htmlGenericControl
                .Attributes["class"]
                .Split(' ')
                .Except(new[] { "", className })
                .Concat(new[] { className })
                .ToArray()));
        }
    }

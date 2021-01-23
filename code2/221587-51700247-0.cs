     public static class WebControlExtension
    {
        public static void RemoveCssClass(this WebControl controlInstance, String css)
        {
            controlInstance.CssClass = String.Join(" ", controlInstance.CssClass.Split(' ').Where(x => x != css).ToArray());
        }
        public static void AddCssClass(this WebControl controlInstance, String css)
        {
            controlInstance.CssClass = String.Join($" {css} ", controlInstance.CssClass.Split(' ').ToArray());
        }
    }

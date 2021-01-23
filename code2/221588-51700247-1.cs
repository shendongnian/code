      public static void RemoveCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            controlInstance.Attributes["class"] = string.Join(" ", strCssClass.Split(' ').Where(x => x != css).ToArray());
        }
        public static void AddCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            controlInstance.Attributes["class"] = string.Join($" {css} ", strCssClass.Split(' ').ToArray());
        }
        public static void RemoveCssClass(this WebControl controlInstance, string css)
        {
            controlInstance.CssClass = string.Join(" ", controlInstance.CssClass.Split(' ').Where(x => x != css).ToArray());
        }
        public static void AddCssClass(this WebControl controlInstance, string css)
        {
            controlInstance.CssClass = string.Join($" {css} ", controlInstance.CssClass.Split(' ').ToArray());
        }

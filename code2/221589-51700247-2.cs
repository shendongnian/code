       public static void RemoveCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            controlInstance.Attributes["class"] = string.Join(" ", strCssClass.Split(' ').Where(x => x != css).ToArray().Distinct());
        }
        public static void AddCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            var cssList = strCssClass.Split(' ').ToArray().Distinct();
           cssList= cssList.Append(css);
            controlInstance.Attributes["class"] = string.Join(" ", cssList);
        }
        /// <summary>
        /// Add or remove specific css class
        /// </summary>
        /// <param name="controlInstance">Control to which css is to be added or remove</param>
        /// <param name="css">            Css class name to be added</param>
        /// <param name="bAddClass">      True to Add / false to remove</param>
        public static void AddOrRemoveCssClass(this HtmlGenericControl controlInstance, string css, bool bAddClass)
        {
            if (bAddClass)
            {
                controlInstance.AddCssClass(css);
            }
            else
            {
                controlInstance.RemoveCssClass(css);
            }
        }
        public static void RemoveCssClass(this WebControl controlInstance, string css)
        {
            controlInstance.CssClass = string.Join(" ", controlInstance.CssClass.Split(' ').Where(x => x != css).ToArray().Distinct());
        }
        public static void AddCssClass(this WebControl controlInstance, string css)
        {
            var cssList = controlInstance.CssClass.Split(' ').ToArray().Distinct();
          cssList=  cssList.Append(css);
            controlInstance.CssClass = string.Join(" ", cssList);
        }
        /// <summary>
        /// Add or remove specific css class
        /// </summary>
        /// <param name="controlInstance">Control to which css is to be added or remove</param>
        /// <param name="css">            Css class name to be added</param>
        /// <param name="bAddClass">      True to Add / false to remove</param>
        public static void AddOrRemoveCssClass(this WebControl controlInstance, string css, bool bAddClass)
        {
            if (bAddClass)
            {
                controlInstance.AddCssClass(css);
            }
            else
            {
                controlInstance.RemoveCssClass(css);
            }
        }

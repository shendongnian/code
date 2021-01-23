    myObject.AddCssClass("someclass");
    myObject.RemoveCssClass("someclass");
    ---------
    public static class WebHelper
    {
        public static void AddCssClass(this WebControl control, string cssClass)
        {
            List<string> classes;
            if (!string.IsNullOrWhiteSpace(control.CssClass))
            {
                classes = control.CssClass.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!classes.Contains(cssClass))
                    classes.Add(cssClass);
            }
            else
            {
                classes = new List<string> {cssClass};
            }
            control.CssClass = string.Join(" ", classes.ToArray());
        }
        public static void RemoveCssClass(this WebControl control, string cssClass)
        {
            List<string> classes = new List<string>();
            if (!string.IsNullOrWhiteSpace(control.CssClass))
            {
                classes = control.CssClass.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            classes.Remove(cssClass);
            control.CssClass = string.Join(" ", classes.ToArray());
        }
    }

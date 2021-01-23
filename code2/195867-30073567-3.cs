    public static void RemoveCssClass(this WebControl control, String css) {
      control.CssClass = String.Join(" ", control.CssClass.Split(' ').Where(x => x != css).ToArray());
    }
    public static void AddCssClass(this WebControl control, String css) {
      control.RemoveCssClass(css);
      css += " " + control.CssClass;
      control.CssClass = css;
    }

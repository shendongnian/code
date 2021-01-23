    public static class HtmlControlExtensions
        {
            public static void Hide(this HtmlControl ctrl)
            {
                if (string.IsNullOrEmpty(ctrl.Attributes.CssStyle["class"]))
                {
                    if (!ctrl.Attributes.CssStyle["class"].Contains("hidden"))
                        ctrl.Attributes.Add("class", ctrl.Attributes.CssStyle["class"] + " hidden");
                }
                else
                {
                    ctrl.Attributes.Add("class", "hidden");
                }
            }
    
            public static void Show(this HtmlControl ctrl)
            {
                if (!string.IsNullOrEmpty(ctrl.Attributes.CssStyle["class"]))
                    if (ctrl.Attributes.CssStyle["class"].Contains("hidden"))
                        ctrl.Attributes.Add("class", ctrl.Attributes.CssStyle["class"].Replace("hidden", ""));
            }
        }

    public static class HtmlControlExtensions
    {
        public static void Hide(this HtmlControl ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl.Attributes["class"]))
            {
                if (!ctrl.Attributes["class"].Contains("hidden"))
                    ctrl.Attributes.Add("class", ctrl.Attributes["class"] + " hidden");
            }
            else
            {
                ctrl.Attributes.Add("class", "hidden");
            }
        }
        public static void Show(this HtmlControl ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl.Attributes["class"]))
                if (ctrl.Attributes["class"].Contains("hidden"))
                    ctrl.Attributes.Add("class", ctrl.Attributes["class"].Replace("hidden", ""));
        }
    }

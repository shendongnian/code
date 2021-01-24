    public static class HtmlControlExt {
        public static HtmlControl AddIdSearch(this HtmlControl ctrl, string name) {
            ctrl.SearchProperties.Add(HtmlControl.PropertyNames.Id, name);
            return ctrl;
        }
    }

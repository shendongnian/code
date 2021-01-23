    public static class ExtensionMethods
    {
        public static MvcHtmlString StateDropDownList(
            this HtmlHelper html
        )
        {
            var stateList = new SelectList(new[]
            {
                new { Key = "Alabama", Value = "Alabama" },
                new { Key = "Idaho", Value = "Idaho" },
                new { Key = "California", Value = "California" }
            }, "Key", "Value");
            return Html.DropDownListFor(x => x.State, stateList, null);
        }
    }

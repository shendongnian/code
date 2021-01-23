    public static class FormHelpers
    {
        public static MvcHtmlString GetStreamFieldEditor(
            this HtmlHelper<YourModelType> html)
        {
            var model = html.ViewData.Model;
            if (model.fiFieldTypeID == 1)
            {
                return html.TextAreaFor(x => x.fiStrValue);
            }
            return html.TextBoxFor(x => x.fiStrValue);
        }
    }

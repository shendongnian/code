    public static class FormExtensions
    {
        public static MvcForm MyBeginForm(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            return htmlHelper.BeginForm(null, null, FormMethod.Post, htmlAttributes);
        }
    }

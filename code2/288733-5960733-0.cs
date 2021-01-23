    public static class HtmlExtensions
    {
        public static IHtmlString Bla(this HtmlHelper<TestModel> htmlHelper)
        {
            TestModel model = htmlHelper.ViewData.Model;
            var value = string.Format("bla bla {0}", model.SomeProperty);
            return MvcHtmlString.Create(value);
        }
    }

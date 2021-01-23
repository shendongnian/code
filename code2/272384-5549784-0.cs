    public static class DisposableExtensions
    {
        public static IDisposable DisposableField(this HtmlHelper htmlHelper, string formName)
        {
            return new DisposableHelper(
                () => htmlHelper.BeginField(formName),
                () => htmlHelper.EndField()
            );
        }
    }

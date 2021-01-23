    public abstract class TextBasedViewPage : System.Web.Mvc.WebViewPage
    {
        public override void Write(object value)
        {
            WriteLiteral(value);
        }
    }
    public abstract class TextBasedViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public override void Write(object value)
        {
            WriteLiteral(value);
        }
    }

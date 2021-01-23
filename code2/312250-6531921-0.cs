    public static class UIExtension
    {
        public static ComponentFactory<TModel> MyExtensions<TModel>(this HtmlHelper<IEnumerable<TModel>> html) where TModel : class
        {
            return new ComponentFactory<TModel>(html);
        }
    }
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ComponentFactory<TModel>
    where TModel : class
    {
        private HtmlHelper _html;
        public ComponentFactory()
        {
        }
        public ComponentFactory(HtmlHelper<IEnumerable<TModel>> html)
        {
            this._html = html;
        }
        public ListComponent<TModel> PrintUsers(IEnumerable<TModel> model)
        {
            return new ListComponent<TModel>(model);
        }
        /* Add other ui components to this factory */
    }
    public class ListComponent<T> : IHtmlString
    {
        private Expression<Func<T, string>> _firstname;
        private Expression<Func<T, string>> _lastname;
        private IEnumerable<T> _model;
        public ListComponent(IEnumerable<T> model)
        {
            this._model = model;
        }
        public ListComponent<T> FirstName(Expression<Func<T, string>> property)
        {
            this._firstname = property;
            return this;
        }
        public ListComponent<T> LastName(Expression<Func<T, string>> property)
        {
            this._lastname = property;
            return this;
        }
        
    public override MvcHtmlString Render()
    {
        TagBuilder container = new TagBuilder("div");
        TagBuilder title = new TagBuilder("div");
        title.InnerHtml = "<b>Names</b>";
        container.InnerHtml = title.ToString(TagRenderMode.Normal);
        TagBuilder ul = new TagBuilder("ul");
        foreach (var item in this._model)
        {
            TagBuilder li = new TagBuilder("li");
            li.SetInnerText(String.Format("{0} {1}", _firstname.Compile()(item), _lastname.Compile()(item)));
            ul.InnerHtml += li.ToString(TagRenderMode.Normal);
        }
        container.InnerHtml += ul.ToString(TagRenderMode.Normal);
        return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal));
    }
    }

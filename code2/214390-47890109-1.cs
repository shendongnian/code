    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, string title) : base(culture, title)
        {
            PageModel = pageModel;
        }
        public T PageModel { get; }
    }

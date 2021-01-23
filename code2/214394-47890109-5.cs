    public class LayoutModel<T> : LayoutModel
    {
        public LayoutModel(T pageModel, string title) : base(title)
        {
            PageModel = pageModel;
        }
        public T PageModel { get; }
    }

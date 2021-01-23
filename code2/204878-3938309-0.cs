    public interface IContentBuilderContainer
    {
        int Count { get; }
        bool Add(string name, Func<IContentBuilder> contentBuilder);
        string RenderHtml();
    }

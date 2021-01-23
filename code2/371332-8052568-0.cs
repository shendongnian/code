    public interface IHtmlGenerator
    {
        void Load(User user);
        void RenderControl(HtmlTextWriter writer);
    }

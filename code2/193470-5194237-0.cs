    public class YourCustomTemplate : ITemplate
    {
        public string rbStartsWithText { get; set; }
        public void InstantiateIn(Control container)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = rbStartsWithText;
            container.Controls.Add(div);
        }
    }

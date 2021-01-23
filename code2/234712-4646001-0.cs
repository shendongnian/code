    public class YourTemplate: ITemplate
    {
        public void InstantiateIn(Control container)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = "sample text, other controls";
            container.Controls.Add(div);
        }
    }

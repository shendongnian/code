    [HtmlTargetElement("div-with-class")]
    public class ClassTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "black-div");
        }
    }
    [HtmlTargetElement("div-with-style")]
    public class StyleTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("style", "height:40px;width: 40px;background-color: black;");
        }
    }
